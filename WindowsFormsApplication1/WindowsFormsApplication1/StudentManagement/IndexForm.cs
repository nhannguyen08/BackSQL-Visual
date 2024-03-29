﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.StudentManagement
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudents.DoubleClick += grdStudents_DoubleClick;
        }

        void grdStudents_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudents.SelectedRows.Count == 1)
            {
                var row = this.grdStudents.SelectedRows[0];
                var studentView = (StudentView)row.DataBoundItem;

                new UpdateForm(studentView.id).ShowDialog();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudent();
        }

        private void ShowAllStudent()
        {
            //this.grdStudents.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentViews = new StudentView[students.Length];
            for (int i = 0; i < students.Length; i++)
                studentViews[i] = new StudentView(students[i]);
            this.grdStudents.DataSource = studentViews;
        }
        void IndexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudent();
        }      
    }
}
