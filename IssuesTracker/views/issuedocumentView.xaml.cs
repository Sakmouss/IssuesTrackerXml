using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IssuesTracker.model;

namespace IssuesTracker.views
{
    /// <summary>
    /// Interaction logic for issuedocumentView.xaml
    /// </summary>
    public partial class issuedocumentView : Window
    {
        FlowDocumentScrollViewer reader = new FlowDocumentScrollViewer();
        public  FlowDocument doc = new FlowDocument();
        public Issue issue;
        public issuedocumentView()
        {
            InitializeComponent();
            issue = new Issue();
            reader.Width = 780;
            reader.Height = 578;
            reader.Background = Brushes.AliceBlue;
          
        }

        string getprojectname(string formername)
        {
            string[] names = formername.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < names.Length; i++)
            {
                sb.Append(names[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
           // FlowDocumentReader reader = docarea.Content as FlowDocumentReader;
          //  FlowDocument doc = reader.Document;
            PrintDialog pd = new PrintDialog();
            if(pd.ShowDialog()==true)
            {
               
                IDocumentPaginatorSource idps = reader.Document;
                pd.PrintDocument(idps.DocumentPaginator, "document printing");
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Paragraph title = new Paragraph();
            title.TextAlignment = TextAlignment.Center;
            title.TextDecorations = TextDecorations.Underline;
            title.FontSize = 20;
            title.Background = Brushes.AliceBlue;
            title.Foreground = Brushes.Red;
            title.Inlines.Add(new Run($"{issue.IssueRelatedProject} Issue N0 {issue.IssueId}"));
            Paragraph createdate = new Paragraph();
            createdate.Inlines.Add(new Run($"Create on:                        {issue.IssueIdentifiedDate.ToString()}"));
            Paragraph projectname = new Paragraph();
            projectname.Inlines.Add(new Run($"Related Project:                 {issue.IssueRelatedProject}"));
            Paragraph assignedperson = new Paragraph();
            assignedperson.Inlines.Add(new Run($"Assigned to:                  {issue.AssignedPersonName}"));
            Paragraph targetdate = new Paragraph();
            targetdate.Inlines.Add(new Run($"Target Resolution Date:           {issue.ResolutionTargetDate.ToString()}"));
            Paragraph actualdate = new Paragraph();
            actualdate.Inlines.Add(new Run($"ActualResolution Date:            {issue.ActualResolutionDate.ToString()}"));
            Paragraph summup = new Paragraph();
            summup.Inlines.Add(issue.IssueSumup);
            Paragraph description = new Paragraph();
            description.Inlines.Add(issue.IssueDescription);
            Paragraph resolutionsump = new Paragraph();
            resolutionsump.Inlines.Add(issue.ResolutionSumup);
            Paragraph progression = new Paragraph();
            progression.Inlines.Add(issue.issueProgression);
            Section section = new Section();
            section.BorderBrush = Brushes.Red;
            section.Padding = new Thickness(10);
            section.BorderThickness = new Thickness(2);
            section.Blocks.Add(createdate);
            section.Blocks.Add(projectname);
            section.Blocks.Add(assignedperson);
            section.Blocks.Add(targetdate);
            section.Blocks.Add(actualdate);
            section.Blocks.Add(new Paragraph(new Bold(new Run("sammury"))));
            section.Blocks.Add(summup);
            section.Blocks.Add(new Paragraph(new Bold(new Run("description"))));
            section.Blocks.Add(description);
            section.Blocks.Add(new Paragraph(new Bold(new Run("Progression"))));
            section.Blocks.Add(progression);
            section.Blocks.Add(new Paragraph(new Bold(new Run("resolution summup"))));
            section.Blocks.Add(resolutionsump);
            doc.Blocks.Add(title);
            doc.Blocks.Add(new Paragraph(new Run("")));
            doc.Blocks.Add(section);
           
            reader.Document =doc;
            docarea.Content = reader;

        }
    }
}
