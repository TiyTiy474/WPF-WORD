using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32; // для использования OpenFileDialog
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
namespace WpfApp6;

partial class MainWindow : Window
{
    //TODO:изменение шрифта, размер шрифта, жирный курсив подчеркнутый,выравнивание,и чтобы весь текст был на весь лист без колонок
    //TODO: и изменения применялись как в ворде то есть к выделенному тексту
    //TODO: надо сделать так что все форматирования то есть размер, шрифт,выравнивание,жирный,подчеркнутный,курсив применялись в PDF файле
    //TODO: спрашивать окно сохранить изменения 
    //TODO: сделать textbox размером как А4 ~(21х29)
    //TODO: переделать сохранение и открытие файла - сериализировать и десериализировать через кастомные методы
    private string selectedFilePath;
    public MainWindow()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Открытие и изменение файла
    /// </summary>
    private void FileOpenButton_Click(object sender, RoutedEventArgs e) 
    {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "Максимкины файлики|*.maxim";
    
    if (openFileDialog.ShowDialog() == true)
    {
        selectedFilePath = openFileDialog.FileName;
        try
        {
            TextRange textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Open))
            {
                string extension = System.IO.Path.GetExtension(selectedFilePath).ToLower();
                switch (extension)
                {
                    case ".rtf":
                        textRange.Load(fileStream, DataFormats.Rtf);
                        break;
                    case ".txt":
                        using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                        {
                            textRange.Text = reader.ReadToEnd();
                        }
                        break;
                    default:
                        textRange.Load(fileStream, DataFormats.Rtf);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
        }
    }
}
    
    private void SetRichTextBoxContent(string text)
    {
        FlowDocument document = new FlowDocument(new Paragraph(new Run(text)))
        {
            PageWidth = 793.7,
            PageHeight = 1122.52,
            ColumnWidth = 793.7,
            ColumnGap = 0
        };

        RichTextBox.Document = document;
    }
    
    /// <summary>
    /// Сохранение файла
    /// </summary>
    private void SaveFileButton_Click(object sender, RoutedEventArgs e)
{
    if (string.IsNullOrEmpty(selectedFilePath))
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Максимкины файлики|*.maxim";
        if (saveFileDialog.ShowDialog() == true)
        {
            selectedFilePath = saveFileDialog.FileName;
        }
        else return;
    }
    try
    {
        TextRange textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
        using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Create))
        {
            string extension = System.IO.Path.GetExtension(selectedFilePath).ToLower();
            switch (extension)
            {
                case ".rtf":
                    textRange.Save(fileStream, DataFormats.Rtf);
                    break;
                case ".txt":
                    using (StreamWriter writer = new StreamWriter(fileStream, Encoding.Default))
                    {
                        writer.Write(textRange.Text);
                    }
                    break;
                default:
                    textRange.Save(fileStream, DataFormats.Rtf);
                    break;
            }
        }
        MessageBox.Show("Файл успешно сохранен");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
    }
}
    
    /// <summary>
    /// печать файла
    /// </summary>
    private void SealFile_Click(object sender, RoutedEventArgs e)
{
    PrintDialog printDialog = new PrintDialog();
    if (printDialog.ShowDialog() == true)
    {
        FlowDocument flowDocument = new FlowDocument();
        TextRange sourceRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
        TextRange targetRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);

        using (MemoryStream ms = new MemoryStream())
        {
            sourceRange.Save(ms, DataFormats.Rtf);
            ms.Seek(0, SeekOrigin.Begin);
            targetRange.Load(ms, DataFormats.Rtf);
        }

        flowDocument.PageWidth = printDialog.PrintableAreaWidth;
        flowDocument.PageHeight = printDialog.PrintableAreaHeight;
        flowDocument.PagePadding = new Thickness(40);
        flowDocument.ColumnWidth = double.MaxValue;

        IDocumentPaginatorSource idpSource = flowDocument;
        printDialog.PrintDocument(idpSource.DocumentPaginator, "Печать документа");
    }
}
    
    /// <summary>
    /// Шрифты
    /// </summary>
    private void Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, ((ComboBoxItem)Font.SelectedItem).Content);
        }
    }
    
    /// <summary>
    /// Размер шрифта
    /// </summary>
    private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(((ComboBoxItem)FontSize.SelectedItem).Content));
        }
    }
    
    /// <summary>
    /// жирный шрифт
    /// </summary>
    private void BoldButton_Click(object sender, RoutedEventArgs e)
    {
        EditingCommands.ToggleBold.Execute(null, RichTextBox);
    }
    
    /// <summary>
    /// курсивный шрифт
    /// </summary>
    private void ItalicButton_Click(object sender, RoutedEventArgs e)
    {
        EditingCommands.ToggleItalic.Execute(null, RichTextBox);
    }
    
    /// <summary>
    /// подчеркунтый шрифт
    /// </summary>
    private void UnderlineButton_Click(object sender, RoutedEventArgs e)
    {
        EditingCommands.ToggleUnderline.Execute(null, RichTextBox);
    }
    
    /// <summary>
    /// выравнивание по левому краю 
    /// </summary>
    private void LeftButton_Click(object sender, RoutedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Left);
        }
    }
    
    /// <summary>
    /// выравнивание по центру
    /// </summary>
    private void CenterButton_Click(object sender, RoutedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
        }
    } 
    
    /// <summary>
    /// выравнивание по правому краю
    /// </summary>
    private void RightButton_Click(object sender, RoutedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Right);
        }
    }
}