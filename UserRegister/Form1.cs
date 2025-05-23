using System.ComponentModel;
using Uwr.OOP.BehavioralPatterns.EventAggregator;
using EventAgg = Uwr.OOP.BehavioralPatterns.EventAggregator;

namespace UserRegister
{
    public partial class Kartoteka : Form,
        EventAgg.ISubscriber<AddUserProfileNotification>,
        EventAgg.ISubscriber<UserProfileSelectedNotification>,
        EventAgg.ISubscriber<EditUserProfileNotification>,
        EventAgg.ISubscriber<CategorySelectedNotification>
    {
        private EventAgg.IEventAggregator _eventAggregator;

        public Kartoteka()
        {
            InitializeComponent();
            InitializeTreeView();
            _eventAggregator = new EventAggregator();
            _eventAggregator.AddSubscriber<AddUserProfileNotification>(this);
            _eventAggregator.AddSubscriber<UserProfileSelectedNotification>(this);
            _eventAggregator.AddSubscriber<EditUserProfileNotification>(this);
            _eventAggregator.AddSubscriber<CategorySelectedNotification>(this);
        }

        ~Kartoteka()
        {
            _eventAggregator.RemoveSubscriber<AddUserProfileNotification>(this);
            _eventAggregator.RemoveSubscriber<UserProfileSelectedNotification>(this);
            _eventAggregator.RemoveSubscriber<EditUserProfileNotification>(this);
            _eventAggregator.RemoveSubscriber<CategorySelectedNotification>(this);
        }

        private void addPerson()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a category to add a person to.");
                return;
            }

            // determine whether to add a student or a teacher
            TreeNode categoryNode = treeView1.SelectedNode.Level == 0
                ? treeView1.SelectedNode : treeView1.SelectedNode.Parent;

            AddEditDialog addEditDialog = new AddEditDialog();
            addEditDialog.ShowDialog();
            if (addEditDialog.DialogResult != DialogResult.OK)
            {
                return;
            }
            Person p = addEditDialog.PersonInfo;
            if (p == null)
            {
                return;
            }

            // Add the person to the tree view
            TreeNode node = new TreeNode(p.Name + " " + p.Surname);
            node.Tag = p;
            categoryNode.Nodes.Add(node);
            treeView1.ExpandAll();
            treeView1.SelectedNode = node;
            treeView1.Focus();
        }

        private void showPerson(Person p)
        {
            if (p == null)
            {
                return;
            }

            hidePanels();
            panelPersonInfo.Visible = true;
            panelPersonInfo.BringToFront();

            surnameTextBox.Text = p.Surname;
            nameTextBox.Text = p.Name;
            birthDateTextBox.Text = p.DateOfBirth.ToShortDateString();
        }

        private void editPerson(TreeNode node)
        {
            Person p = (Person)node.Tag;
            AddEditDialog addEditDialog = new AddEditDialog(p);
            addEditDialog.ShowDialog();
            if (addEditDialog.DialogResult != DialogResult.OK)
            {
                return;
            }
            p = addEditDialog.PersonInfo;
            if (p == null)
            {
                return;
            }
            // Update the person in the tree view
            node.Text = p.Name + " " + p.Surname;
            node.Tag = p;
            showPerson(p);
        }

        private void hidePanels()
        {
            categoryPanel.Visible = false;
            panelPersonInfo.Visible = false;
        }

        private void showCategory(TreeNode categoryNode)
        {
            hidePanels();
            categoryPanel.Visible = true;
            categoryPanel.BringToFront();

            dataGridView1.Rows.Clear();
            //TreeNode categoryNode = treeView1.SelectedNode;
            for (int i = 0; i < categoryNode.Nodes.Count; i++)
            {
                Person p = (Person)categoryNode.Nodes[i].Tag;
                dataGridView1.Rows.Add(p.Surname, p.Name, p.DateOfBirth.ToShortDateString());
            }
        }

        private void InitializeTreeView()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Studenci");
            treeView1.Nodes.Add("Wykładowcy");
            treeView1.EndUpdate();
        }

        public new void Handle(AddUserProfileNotification notification)
        {
            addPerson();
        }

        public new void Handle(UserProfileSelectedNotification notification)
        {
            showPerson(notification.Data);
        }

        public new void Handle(EditUserProfileNotification notification)
        {
            editPerson(notification.Data);
        }

        public new void Handle(CategorySelectedNotification notification)
        {
            showCategory(notification.Data);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                _eventAggregator.Publish(new CategorySelectedNotification(e.Node));
            }
            else
            {
                _eventAggregator.Publish(new UserProfileSelectedNotification(e.Node.Tag as Person));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _eventAggregator.Publish(new AddUserProfileNotification()); 
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Get the clicked node
            TreeNode clickedNode = e.Node;

            // Perform an action based on the clicked node
            MessageBox.Show("You clicked: " + clickedNode.Text);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                MessageBox.Show("Please select a person to edit.");
                return;
            }
            _eventAggregator.Publish(new EditUserProfileNotification(treeView1.SelectedNode));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
