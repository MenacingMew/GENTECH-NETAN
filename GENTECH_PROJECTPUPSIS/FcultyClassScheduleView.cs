using GENTECH_PROJECTPUPSIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentEnrollmentDraft
{
    public partial class FcultyClassScheduleView : UserControl, INavigationSource
    {
        public FcultyClassScheduleView()
        {
            InitializeComponent();
            // wire edit button like Schedule2
            this.btnEdit.Click += Button1_Click;

        }

        public event EventHandler<NavigationRequestedEventArgs> NavigationRequested;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, new NavigationRequestedEventArgs(typeof(FacultyHomePagePanel)));
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            InitializeScheduleGrid();
        }

        // Drag/drop state
        private int _dragRow = -1;
        private int _dragCol = -1;
        private int _dragDuration = 1;
        private bool _isEditMode = false;

        // track changes during edit session so we can show confirmation and optionally revert
        private class ChangeRecord
        {
            public string Course { get; set; }
            public int OrigRow { get; set; }
            public int OrigCol { get; set; }
            public int OrigDuration { get; set; }
            public int NewRow { get; set; }
            public int NewCol { get; set; }
            public int NewDuration { get; set; }
        }

        private List<ChangeRecord> _changes = new List<ChangeRecord>();
        private bool _hasConfirmedChanges = false;

        private string GetDayName(int col)
        {
            if (col <= 0 || col >= dgvScheduleEditor.Columns.Count) return "";
            return dgvScheduleEditor.Columns[col].HeaderText;
        }

        private string GetTimeRange(int startRow, int duration)
        {
            if (startRow < 0 || startRow >= dgvScheduleEditor.Rows.Count) return "";
            var start = dgvScheduleEditor.Rows[startRow].Cells[0].Value?.ToString() ?? "";
            int endRow = Math.Min(dgvScheduleEditor.Rows.Count - 1, startRow + duration - 1);
            var end = dgvScheduleEditor.Rows[endRow].Cells[0].Value?.ToString() ?? "";
            return $"{start} - {end}";
        }

        // drag data container
        private class CourseDragInfo
        {
            public string Name { get; set; }
            public int Duration { get; set; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SetEditMode(!_isEditMode);
        }

        private void SetEditMode(bool enabled)
        {
            _isEditMode = enabled;
            if (enabled)
            {
                // entering edit mode clears any previously confirmed submission state
                _hasConfirmedChanges = false;
            }
            // allow drag/drop only in edit mode
            dgvScheduleEditor.AllowDrop = enabled;
            // keep grid readable but prevent editing cell values unless in edit mode
            dgvScheduleEditor.ReadOnly = !enabled;
            // update button text
            btnEdit.Text = enabled ? "Done" : "Edit";
            if (!enabled)
            {
                // leaving edit mode: show confirmation of changes
                if (_changes.Any())
                {
                    // filter meaningful changes (start/time changed)
                    var meaningful = _changes.Where(ch => ch.OrigRow != ch.NewRow || ch.OrigCol != ch.NewCol || ch.OrigDuration != ch.NewDuration).ToList();

                    if (!meaningful.Any())
                    {
                        // all recorded changes are no-ops (start time unchanged) -> revert and notify
                        _changes.Clear();
                        MessageBox.Show("No changes were made. The schedule will remain the same.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("You made the following schedule changes:");
                        foreach (var ch in meaningful)
                        {
                            string origTime = GetTimeRange(ch.OrigRow, ch.OrigDuration);
                            string newTime = GetTimeRange(ch.NewRow, ch.NewDuration);
                            string origDay = GetDayName(ch.OrigCol);
                            string newDay = GetDayName(ch.NewCol);
                            sb.AppendLine($"{ch.Course}: {origDay} {origTime} -> {newDay} {newTime}");
                        }
                        sb.AppendLine();
                        sb.AppendLine("Confirm changes?");
                        var res = MessageBox.Show(sb.ToString(), "Confirm Schedule Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                            // revert all recorded changes
                            foreach (var ch in _changes.AsEnumerable().Reverse())
                            {
                                ClearCourseCell(ch.NewRow, ch.NewCol);
                                SetCourseCell(ch.OrigRow, ch.OrigCol, ch.Course, ch.OrigDuration);
                            }
                        }
                        else
                        {
                            // user confirmed the changes — mark that there are confirmed changes pending submission
                            _hasConfirmedChanges = true;
                        }
                        _changes.Clear();
                    }
                }
            }
        }

        private void InitializeScheduleGrid()
        {
            // Configure columns: Time + Monday..Friday
            dgvScheduleEditor.AllowDrop = true;
            dgvScheduleEditor.Columns.Clear();
            dgvScheduleEditor.RowHeadersVisible = false;
            dgvScheduleEditor.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvScheduleEditor.Columns.Add("Time", "");
            dgvScheduleEditor.Columns[0].Width = 80;
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            foreach (var d in days)
            {
                var c = new DataGridViewTextBoxColumn();
                c.Name = d;
                c.HeaderText = d;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvScheduleEditor.Columns.Add(c);
            }

            // Rows for times from 7:00 AM to 8:00 PM (30-minute slots)
            var times = new List<string>();
            var start = new TimeSpan(7, 0, 0);
            var end = new TimeSpan(20, 0, 0);
            for (var t = start; t <= end; t = t.Add(TimeSpan.FromMinutes(30)))
            {
                // Convert TimeSpan to DateTime for AM/PM formatting (non-military)
                times.Add(DateTime.Today.Add(t).ToString("h:mm tt"));
            }
            dgvScheduleEditor.Rows.Clear();
            foreach (var t in times)
            {
                int idx = dgvScheduleEditor.Rows.Add();
                dgvScheduleEditor.Rows[idx].Cells[0].Value = t;
                dgvScheduleEditor.Rows[idx].Height = 48;
                dgvScheduleEditor.Rows[idx].Cells[0].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvScheduleEditor.Rows[idx].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                // no special break rows in the new schedule
            }

            // Sample entries to match the illustration (can be replaced by real data)
            // For demonstration, populate a few sample slots with durations
            // Note: rows correspond to 7:00=0, 7:30=1, 8:00=2, ... each unit = 30 minutes
            SetCourseCell(8, 1, "Free Elective 2", duration: 6); // 7:00-10:00 Monday (3 hours = 6 slots)
            SetCourseCell(3, 3, "Network Administration", duration: 4); // 7:00-8:00 Wednesday
            SetCourseCell(8, 3, "Network Administration", duration: 6); // 7:00-8:00 Wednesday
            SetCourseCell(22, 3, "Object Oriented Programming", duration: 2); // 9:00-10:00 Monday
            SetCourseCell(8, 4, "Object Oriented Programming", duration: 6); // 9:00-11:00 Monday (2 hours = 4 slots)
            SetCourseCell(16, 4, "Interactive Prgramming & Technologies 1", duration: 4); // 9:00-11:00 Tuesday (2 hours = 4 slots)
            SetCourseCell(21, 4, "Interactive Prgramming & Technologies 1", duration: 6); // 9:00-11:00 Tuesday (2 hours = 4 slots)
            SetCourseCell(16, 1, "Quantitative Methods with Modeling and Simulation", duration: 6); // 1:00-2:00 PM Wed
            SetCourseCell(7, 5, "PATHFit", duration: 4); // 8:00-9:00 Thursday
            SetCourseCell(8, 6, "Human Computer Interaction", duration: 6); // 2:00-3:00 Monday
            SetCourseCell(16, 6, "Information Management", duration: 4); // 1:00-2:00 Friday
            SetCourseCell(21, 6, "Information Management", duration: 6); // 1:00-2:00 Friday

            // Events for drag/drop will be enabled only in edit mode
            // handlers are attached but will check _isEditMode before acting
            dgvScheduleEditor.CellMouseDown += DgvScheduleEditor_CellMouseDown;
            dgvScheduleEditor.DragOver += DgvScheduleEditor_DragOver;
            dgvScheduleEditor.DragDrop += DgvScheduleEditor_DragDrop;

            // default to non-editable
            SetEditMode(false);
        }

        private void SetCourseCell(int row, int col, string course, int duration = 1)
        {
            if (row < 0 || col < 1) return;
            // Ensure duration fits
            if (duration < 1) duration = 1;
            if (row + duration - 1 >= dgvScheduleEditor.Rows.Count) return;

            // Check that all target cells are free
            for (int r = row; r < row + duration; r++)
            {
                var ccell = dgvScheduleEditor.Rows[r].Cells[col];
                if (ccell.Tag != null) return; // occupied
            }

            var topCell = dgvScheduleEditor.Rows[row].Cells[col];
            topCell.Value = course;
            topCell.Style.BackColor = GetCourseColor(course);
            topCell.Style.ForeColor = Color.White;
            topCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            topCell.Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            topCell.Tag = duration; // store duration (in 30-min units)

            // mark following rows as occupied and style them to match the top cell
            for (int r = row + 1; r < row + duration; r++)
            {
                var ccell = dgvScheduleEditor.Rows[r].Cells[col];
                ccell.Value = null;
                ccell.Tag = -1; // marker for occupied by span
                ccell.Style.BackColor = GetCourseColor(course);
                ccell.Style.ForeColor = Color.White;
            }
            // refresh to trigger repaint
            dgvScheduleEditor.InvalidateColumn(col);
        }

        private void ClearCourseCell(int row, int col)
        {
            if (row < 0 || col < 1) return;
            var cell = dgvScheduleEditor.Rows[row].Cells[col];
            // if this is a continuation cell, find the top cell
            if (cell.Tag != null && cell.Tag is int && (int)cell.Tag == -1)
            {
                // walk up to find top
                int top = row;
                while (top >= 0)
                {
                    var cc = dgvScheduleEditor.Rows[top].Cells[col];
                    if (cc.Tag != null && cc.Tag is int && (int)cc.Tag > 0) break;
                    top--;
                }
                if (top < 0) return;
                cell = dgvScheduleEditor.Rows[top].Cells[col];
                row = top;
            }

            int duration = 1;
            if (cell.Tag != null && cell.Tag is int && (int)cell.Tag > 0)
            {
                duration = (int)cell.Tag;
            }

            // clear block
            for (int r = row; r < row + duration; r++)
            {
                var cc = dgvScheduleEditor.Rows[r].Cells[col];
                cc.Value = null;
                cc.Tag = null;
                cc.Style.BackColor = Color.Empty;
                cc.Style.ForeColor = Color.Black;
                cc.Style.Font = dgvScheduleEditor.Font;
            }
            dgvScheduleEditor.InvalidateColumn(col);
        }

        private void NormalizeCellsAfterClear(int srcRow, int srcCol)
        {
            // After clearing a multi-row block, make sure no residual background remains in neighboring cells
            for (int r = 0; r < dgvScheduleEditor.Rows.Count; r++)
            {
                for (int c = 1; c < dgvScheduleEditor.Columns.Count; c++)
                {
                    var cell = dgvScheduleEditor.Rows[r].Cells[c];
                    if (cell.Tag == null && (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())))
                    {
                        cell.Style.BackColor = Color.Empty;
                        cell.Style.ForeColor = Color.Black;
                        cell.Style.Font = dgvScheduleEditor.Font;
                    }
                }
            }
            dgvScheduleEditor.Invalidate();
        }

        private Color GetCourseColor(string course)
        {
            switch ((course ?? string.Empty).ToLowerInvariant())
            {
                case "free elective 2": return Color.FromArgb(66, 133, 244);
                case "interactive prgramming & technologies 1": return Color.FromArgb(76, 175, 80);
                case "quantitative methods with modeling and simulation": return Color.FromArgb(255, 193, 7);
                case "object oriented programming": return Color.FromArgb(244, 67, 54);
                case "information management": return Color.FromArgb(156, 39, 176);
                case "network administration": return Color.FromArgb(233, 30, 99);
                case "pathfit": return Color.FromArgb(103, 58, 183);
                case "human computer interaction": return Color.FromArgb(97, 97, 97);
                default: return Color.FromArgb(96, 125, 139);
            }
        }

        // (Custom painting removed — cells use background colors instead)

        private void DgvScheduleEditor_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_isEditMode) return;

            // Only start drag if user clicked on a course cell that matches lblCourse text
            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return;
            // find the top cell for this block (if this is a continuation)
            int topRow = e.RowIndex;
            var cell = dgvScheduleEditor.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag != null && cell.Tag is int && (int)cell.Tag == -1)
            {
                // walk up to find top
                while (topRow >= 0)
                {
                    var cc = dgvScheduleEditor.Rows[topRow].Cells[e.ColumnIndex];
                    if (cc.Tag != null && cc.Tag is int && (int)cc.Tag > 0) break;
                    topRow--;
                }
            }
            var topCell = dgvScheduleEditor.Rows[topRow].Cells[e.ColumnIndex];
            if (topCell.Value == null) return;
            var course = topCell.Value.ToString();
            if (!string.Equals(course?.Trim(), lblCourse.Text?.Trim(), StringComparison.OrdinalIgnoreCase)) return;

            _dragRow = topRow;
            _dragCol = e.ColumnIndex;
            _dragDuration = 1;
            if (topCell.Tag != null && topCell.Tag is int && (int)topCell.Tag > 0) _dragDuration = (int)topCell.Tag;

            var info = new CourseDragInfo { Name = course, Duration = _dragDuration };
            dgvScheduleEditor.DoDragDrop(info, DragDropEffects.Move);
        }

        private void DgvScheduleEditor_DragOver(object sender, DragEventArgs e)
        {
            if (!_isEditMode) { e.Effect = DragDropEffects.None; return; }

            Point p = dgvScheduleEditor.PointToClient(new Point(e.X, e.Y));
            var ht = dgvScheduleEditor.HitTest(p.X, p.Y);
            if (ht.RowIndex < 0 || ht.ColumnIndex <= 0)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            // Only allow drop if target block of rows is free for the dragged duration
            var dragInfo = e.Data.GetData(typeof(CourseDragInfo)) as CourseDragInfo;
            if (dragInfo == null || _dragRow < 0 || _dragCol <= 0)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            int duration = dragInfo.Duration;
            // check bounds
            if (ht.RowIndex + duration - 1 >= dgvScheduleEditor.Rows.Count)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // ensure all target cells are not occupied
            bool ok = true;
            for (int r = ht.RowIndex; r < ht.RowIndex + duration; r++)
            {
                var ccell = dgvScheduleEditor.Rows[r].Cells[ht.ColumnIndex];
                if (ccell.Tag != null) ok = false;
            }

            e.Effect = ok ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void DgvScheduleEditor_DragDrop(object sender, DragEventArgs e)
        {
            if (!_isEditMode) return;

            Point p = dgvScheduleEditor.PointToClient(new Point(e.X, e.Y));
            var ht = dgvScheduleEditor.HitTest(p.X, p.Y);
            if (ht.RowIndex < 0 || ht.ColumnIndex <= 0) return;
            if (_dragRow < 0 || _dragCol <= 0) return;
            var info = e.Data.GetData(typeof(CourseDragInfo)) as CourseDragInfo;
            if (info == null) return;
            var data = info.Name;
            int duration = info.Duration;
            if (string.IsNullOrWhiteSpace(data)) return;

            // ensure space available (already checked in DragOver but re-check)
            if (ht.RowIndex + duration - 1 >= dgvScheduleEditor.Rows.Count)
            {
                // overtime: ask user if they want to place at latest possible start time
                var res = MessageBox.Show("The course duration exceeds schedule bounds. Place at latest possible start time?", "Overtime", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int newStart = dgvScheduleEditor.Rows.Count - duration;
                    if (newStart < 0) return;
                    SetCourseCell(newStart, ht.ColumnIndex, data, duration);
                    ClearCourseCell(_dragRow, _dragCol);
                    NormalizeCellsAfterClear(_dragRow, _dragCol);
                    _dragRow = -1; _dragCol = -1; _dragDuration = 1;
                }
                return;
            }

            for (int r = ht.RowIndex; r < ht.RowIndex + duration; r++)
            {
                var ccell = dgvScheduleEditor.Rows[r].Cells[ht.ColumnIndex];
                if (ccell.Tag != null)
                {
                    // occupied -> show error, no swapping allowed
                    MessageBox.Show("Cannot move: target slot is occupied. Only empty slots are allowed.", "Cannot Move", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // abort
                }
            }

            // record original location
            var origRow = _dragRow;
            var origCol = _dragCol;
            var origTopCell = dgvScheduleEditor.Rows[origRow].Cells[origCol];
            int origDuration = 1;
            if (origTopCell.Tag is int && (int)origTopCell.Tag > 0) origDuration = (int)origTopCell.Tag;

            // Move the course block
            SetCourseCell(ht.RowIndex, ht.ColumnIndex, data, duration);
            ClearCourseCell(_dragRow, _dragCol);
            // ensure clearing removed any leftover styling
            NormalizeCellsAfterClear(_dragRow, _dragCol);

            // record change for confirmation later
            var existing = _changes.FirstOrDefault(x => string.Equals(x.Course, data, StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                _changes.Add(new ChangeRecord
                {
                    Course = data,
                    OrigRow = origRow,
                    OrigCol = origCol,
                    OrigDuration = origDuration,
                    NewRow = ht.RowIndex,
                    NewCol = ht.ColumnIndex,
                    NewDuration = duration
                });
            }
            else
            {
                // update only the "new" values so history is not duplicated
                existing.NewRow = ht.RowIndex;
                existing.NewCol = ht.ColumnIndex;
                existing.NewDuration = duration;
            }

            // reset drag state
            _dragRow = -1;
            _dragCol = -1;
            _dragDuration = 1;
            // ensure selection cleared
            dgvScheduleEditor.ClearSelection();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            // Inform the user that their schedule change request was submitted.
            // If there are unconfirmed changes, prompt the user to confirm first.
            if (_changes != null && _changes.Count > 0)
            {
                MessageBox.Show("Please finish editing and confirm changes before submitting the request.", "Pending Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If there are no confirmed changes, inform user that the request will be denied and do not send
            if (!_hasConfirmedChanges)
            {
                MessageBox.Show("No schedule changes were detected. The request will be denied and will not be sent to the administrator.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // At this point we have confirmed changes to submit
            MessageBox.Show("Your schedule change request has been submitted to the administrator.", "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Reset the confirmed flag after submission
            _hasConfirmedChanges = false;
        }
    }
}
