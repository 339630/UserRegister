using System.ComponentModel;
using EventAgg = Uwr.OOP.BehavioralPatterns.EventAggregator;

namespace UserRegister
{
    public partial class Form1 : Form, EventAgg.ISubscriber<string>
    {
        private EventAgg.IEventAggregator _eventAggregator;

        public Form1(EventAgg.IEventAggregator eventAggregator)
        {
            InitializeComponent();
            InitializeTreeView();
            _eventAggregator = eventAggregator;
        }

        private void addPerson()
        {
            // determine whether to add a student or a teacher
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a category to add a person to.");
                return;
            }

            TreeNode categoryNode = treeView1.SelectedNode.Level == 0
                ? treeView1.SelectedNode : treeView1.SelectedNode.Parent;
            //if (treeView1.SelectedNode.Level == 0)
            //{
            //    category = treeView1.SelectedNode;
            //} else if (treeView1.SelectedNode.Level == 1)
            //{
            //    category = treeView1.SelectedNode.Parent;
            //}

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

        private void editPerson()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a person to edit.");
                return;
            }
            Person p = (Person)treeView1.SelectedNode.Tag;
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
            treeView1.SelectedNode.Text = p.Name + " " + p.Surname;
            treeView1.SelectedNode.Tag = p;
            showPerson(p);
        }

        private void hidePanels()
        {
            categoryPanel.Visible = false;
            panelPersonInfo.Visible = false;
        }

        private void showCategory()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a category to show");
                return;
            }

            hidePanels();
            categoryPanel.Visible = true;
            categoryPanel.BringToFront();

            dataGridView1.Rows.Clear();
            TreeNode categoryNode = treeView1.SelectedNode;
            for (int i = 0; i < categoryNode.Nodes.Count; i++)
            {
                Person p = (Person)categoryNode.Nodes[i].Tag;
                dataGridView1.Rows.Add(p.Surname, p.Name, p.DateOfBirth.ToShortDateString());
            }
        }

        // Populates a TreeView control with example nodes. 
        private void InitializeTreeView()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Studenci");
            //treeView1.Nodes[0].Nodes.Add("Child 1");
            //treeView1.Nodes[0].Nodes.Add("Child 2");
            treeView1.Nodes.Add("Wyk³adowcy");
            //treeView1.Nodes[1].Nodes.Add("Child 3");
            treeView1.EndUpdate();
        }

        public new void Handle(string notification)
        {
            // MessageBox.Show(notification);
            if (notification == "AddUserProfileNotification")
            {
                addPerson();
            }
            else if (notification == "UserProfileSelectedNotification")
            {
                //showPerson();
            } else if (notification == "EditUserProfileNotification")
            {
                editPerson();
            } else if (notification == "CategorySelectedNotification")
            {
                showCategory();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                //panelPersonInfo.Visible = false;
                _eventAggregator.Publish("CategorySelectedNotification");
            } else
            {
                showPerson(e.Node.Tag as Person);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("test");
            _eventAggregator.Publish("AddUserProfileNotification");
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
            _eventAggregator.Publish("EditUserProfileNotification");
            // TODO: add payload to the event?
            // add payload of category and 
        }
    }
}
