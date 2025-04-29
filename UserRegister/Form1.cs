using System.ComponentModel;
using EventAgg = Uwr.OOP.BehavioralPatterns.EventAggregator;

namespace UserRegister
{
    using Notification = KeyValuePair<EventType, object?>;

    public partial class Kartoteka : Form, EventAgg.ISubscriber<Notification>
    {
        private EventAgg.IEventAggregator _eventAggregator;

        public Kartoteka(EventAgg.IEventAggregator eventAggregator)
        {
            InitializeComponent();
            InitializeTreeView();
            _eventAggregator = eventAggregator;
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
            treeView1.Nodes.Add("Wyk³adowcy");
            treeView1.EndUpdate();
        }

        public new void Handle(Notification notification)
        {
            if (notification.Key == EventType.AddUserProfileNotification)
            {
                addPerson();
            }
            else if (notification.Key == EventType.UserProfileSelectedNotification)
            {
                if (notification.Value == null)
                {
                    return;
                }
                showPerson(notification.Value as Person);
            }
            else if (notification.Key == EventType.EditUserProfileNotification)
            {
                if (notification.Value == null)
                {
                    return;
                }
                editPerson(notification.Value as TreeNode);
            }
            else if (notification.Key == EventType.CategorySelectedNotification)
            {
                if (notification.Value == null)
                {
                    return;
                }
                showCategory(notification.Value as TreeNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                _eventAggregator.Publish(new Notification(EventType.CategorySelectedNotification, e.Node));
            }
            else
            {
                _eventAggregator.Publish(new Notification(EventType.UserProfileSelectedNotification, e.Node.Tag));
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _eventAggregator.Publish(new Notification(EventType.AddUserProfileNotification, null));
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
            _eventAggregator.Publish(new Notification(EventType.EditUserProfileNotification, treeView1.SelectedNode));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
