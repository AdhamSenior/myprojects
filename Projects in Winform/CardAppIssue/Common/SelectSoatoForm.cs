using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Common
{
    public partial class SelectSoatoForm : Form
    {
        public int ParentId { get; set; }
        public string CurrentItem { get; set; }
        public int SelectedItemId { get; set; }
        public string SelectedItem { get; set; }
        public string Level { get; set; }

        public SelectSoatoForm()
        {
            InitializeComponent();
            Text = Texts.Regions;
            kbtnSelect.Text = Texts.Select;

            Load += SelectSoatoForm_Load;
            kbtnSelect.Click += kbtnSelect_Click;

            ktvItems.BeforeSelect += ktvItems_BeforeSelect;
        }
        void ktvItems_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = Level.Contains(e.Node.Level.ToSafeString());
        }
        void kbtnSelect_Click(object sender, EventArgs e)
        {
            if (!ReferenceEquals(ktvItems.SelectedNode, null))
            {
                SelectedItem = ktvItems.SelectedNode.Text;
                SelectedItemId = (int)ktvItems.SelectedNode.Tag;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        void SelectSoatoForm_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Level))
                Level = "0,1,2,4";

            InitTree();
        }
        void InitTree()
        {
            ktvItems.Nodes.Clear();

            var root = new TreeNode { Name = "0", Text = Texts.Regions, Tag = 0 };
            if (ParentId != 0)
            {
                var rs = Soato.Items.Where(wh => wh.Id == ParentId).ToList();
                if (rs.Count == 1)
                {
                    var item = rs.First();
                    root.Name = item.Id.ToString();
                    root.Text = item.ToString();
                    root.Tag = item.Id;
                }
            }

            LoadNode(root, (int)root.Tag);
            ktvItems.Nodes.Add(root);
            root.Expand();

            var node = ktvItems.Nodes.Find(CurrentItem, true).FirstOrDefault();
            if (!ReferenceEquals(node, null))
            {
                ktvItems.SelectedNode = node;
                ktvItems.SelectedNode.Expand();
            }
        }
        void LoadNode(TreeNode node, int parentId)
        {
            var rs = Soato.Items.Where(wh => wh.ParentId == parentId).ToList();
            foreach (var r in rs)
            {
                var item = new TreeNode { Name = r.Id.ToString(), Text = r.ToString(), Tag = r.Id };
                node.Nodes.Add(item);
                LoadNode(item, r.Id);
            }
        }
    }
}
