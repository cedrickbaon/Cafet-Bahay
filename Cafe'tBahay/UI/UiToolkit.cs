using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    // Shared WinForms builder. No changes to existing *.Designer.cs files are required.
    internal static class UiToolkit
    {
        internal static TableLayoutPanel Layout(UserControl owner, string title, int fieldsHeight = 145)
        {
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1,
                RowCount = 3, Padding = new Padding(14), BackColor = Color.FromArgb(245,247,250) };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, fieldsHeight));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.Controls.Add(new Label { Text = title, Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.FromArgb(31,41,55) }, 0, 0);
            owner.Controls.Clear();
            owner.Controls.Add(layout);
            return layout;
        }
        internal static FlowLayoutPanel Bar()
        {
            return new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = true, AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(0,4,0,0) };
        }
        internal static TextBox Text(FlowLayoutPanel bar, string label, int width = 140)
        {
            bar.Controls.Add(new Label { Text = label, AutoSize = true, Padding = new Padding(4,8,1,0) });
            var box = new TextBox { Width = width, Font = new Font("Segoe UI", 10), Margin = new Padding(1,2,10,6) };
            bar.Controls.Add(box); return box;
        }
        internal static ComboBox Combo(FlowLayoutPanel bar, string label, int width = 150)
        {
            bar.Controls.Add(new Label { Text = label, AutoSize = true, Padding = new Padding(4,8,1,0) });
            var c = new ComboBox { Width = width, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(1,2,10,6) };
            bar.Controls.Add(c); return c;
        }
        internal static NumericUpDown Num(FlowLayoutPanel bar, string label, decimal max, int decimalPlaces = 0)
        {
            bar.Controls.Add(new Label { Text = label, AutoSize = true, Padding = new Padding(4,8,1,0) });
            var c = new NumericUpDown { Width = 115, Minimum = 0, Maximum = max, DecimalPlaces = decimalPlaces,
                Increment = decimalPlaces == 0 ? 1 : .25m, Margin = new Padding(1,2,10,6) };
            bar.Controls.Add(c); return c;
        }
        internal static Button Button(FlowLayoutPanel bar, string text, Action action)
        {
            var b = new Button { Text = text, AutoSize = true, MinimumSize = new Size(100,28),
                BackColor = Color.FromArgb(31, 52, 77), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Margin = new Padding(4,1,7,6) };
            b.Click += (s,e) => Safe(action); bar.Controls.Add(b); return b;
        }
        internal static DataGridView Grid()
        {
            return new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = true,
                ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White };
        }
        internal static DataRow Selected(DataGridView grid)
        {
            var view = grid.CurrentRow == null ? null : grid.CurrentRow.DataBoundItem as DataRowView;
            if (view == null) throw new InvalidOperationException("Select a record first.");
            return view.Row;
        }
        internal static int Id(DataRow row) { return Convert.ToInt32(row["Id"]); }
        internal static string Str(DataRow row, string key)
        { return row.IsNull(key) ? "" : Convert.ToString(row[key]); }
        internal static void BindCombo(ComboBox combo, DataTable dt, bool all = false)
        {
            var rows = dt.Copy();
            if (all) { var r=rows.NewRow(); r["Id"] = 0; r["Name"] = "All categories"; rows.Rows.InsertAt(r,0); }
            combo.DataSource = rows; combo.DisplayMember = "Name"; combo.ValueMember = "Id";
        }
        internal static int? SelectedId(ComboBox combo)
        { return combo.SelectedValue is int ? (int?)Convert.ToInt32(combo.SelectedValue) : null; }
        internal static void Safe(Action action)
        {
            try { action(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Café't Bahay", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        internal static void Info(string text) { MessageBox.Show(text, "Café't Bahay", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    }
}
