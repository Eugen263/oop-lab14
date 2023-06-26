using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace FileDirectoryManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Створення каталогу
        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            string directoryPath = txtDirectoryPath.Text;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                MessageBox.Show("Каталог успішно створено!");
            }
            else
            {
                MessageBox.Show("Каталог вже існує!");
            }
        }

        // Перенесення каталогу
        private void btnMoveDirectory_Click(object sender, EventArgs e)
        {
            string sourceDirectoryPath = txtDirectoryPath.Text;
            string destinationDirectoryPath = txtDestinationDirectoryPath.Text;
            if (Directory.Exists(sourceDirectoryPath))
            {
                if (!Directory.Exists(destinationDirectoryPath))
                {
                    Directory.Move(sourceDirectoryPath, destinationDirectoryPath);
                    MessageBox.Show("Каталог успішно перенесено!");
                }
                else
                {
                    MessageBox.Show("Каталог призначення вже існує!");
                }
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }

        // Копіювання каталогу
        private void btnCopyDirectory_Click(object sender, EventArgs e)
        {
            string sourceDirectoryPath = txtDirectoryPath.Text;
            string destinationDirectoryPath = txtDestinationDirectoryPath.Text;
            if (Directory.Exists(sourceDirectoryPath))
            {
                if (!Directory.Exists(destinationDirectoryPath))
                {
                    Directory.CreateDirectory(destinationDirectoryPath);
                }
                DirectoryCopy(sourceDirectoryPath, destinationDirectoryPath, true);
                MessageBox.Show("Каталог успішно скопійовано!");
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }

        // Видалення каталогу
        private void btnDeleteDirectory_Click(object sender, EventArgs e)
        {
            string directoryPath = txtDirectoryPath.Text;
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
                MessageBox.Show("Каталог успішно видалено!");
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }

        // Створення файлу
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                MessageBox.Show("Файл успішно створено!");
            }
            else
            {
                MessageBox.Show("Файл вже існує!");
            }
        }

        // Перенесення файлу
        private void createDirectoryBtn_Click(object sender, EventArgs e)
        {
            string path = directoryPathTextBox.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Directory created successfully!");
            }
            else
            {
                MessageBox.Show("Directory already exists!");
            }
        }

        private void copyDirectoryBtn_Click(object sender, EventArgs e)
        {
            string sourcePath = directoryPathTextBox.Text;
            string destPath = destinationDirectoryTextBox.Text;
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                string[] files = Directory.GetFiles(sourcePath);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(destPath, fileName);
                    File.Copy(file, destFile, true);
                }
                MessageBox.Show("Directory copied successfully!");
            }
            else
            {
                MessageBox.Show("Source directory does not exist!");
            }
        }

        private void moveDirectoryBtn_Click(object sender, EventArgs e)
        {
            string sourcePath = directoryPathTextBox.Text;
            string destPath = destinationDirectoryTextBox.Text;
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                string[] files = Directory.GetFiles(sourcePath);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(destPath, fileName);
                    File.Move(file, destFile);
                }
                Directory.Delete(sourcePath);
                MessageBox.Show("Directory moved successfully!");
            }
            else
            {
                MessageBox.Show("Source directory does not exist!");
            }
        }

        private void deleteDirectoryBtn_Click(object sender, EventArgs e)
        {
            string path = directoryPathTextBox.Text;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                MessageBox.Show("Directory deleted successfully!");
            }
            else
            {
                MessageBox.Show("Directory does not exist!");
            }
        }

        private void createFileBtn_Click(object sender, EventArgs e)
        {
            string path = filePathTextBox.Text;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                MessageBox.Show("File created successfully!");
            }
            else
            {
                MessageBox.Show("File already exists!");
            }
        }

        private void copyFileBtn_Click(object sender, EventArgs e)
        {
            string sourceFile = filePathTextBox.Text;
            string destFile = destinationFileTextBox.Text;
            if (File.Exists(sourceFile))
            {
                File.Copy(sourceFile, destFile, true);
                MessageBox.Show("File copied successfully!");
            }
            else
            {
                MessageBox.Show("Source file does not exist!");
            }
        }

        private void moveFileBtn_Click(object sender, EventArgs e)
        {
            string sourceFile = filePathTextBox.Text;
            string destFile = destinationFileTextBox.Text;
            if (File.Exists(sourceFile))
            {
                File.Move(sourceFile, destFile);
                MessageBox.Show("File moved successfully!");
            }
            else
            {
                MessageBox.Show("Source file does not exist!");
            }
        }

        private void deleteFileBtn_Click(object sender, EventArgs e)
        {
            string path = filePathTextBox.Text;
            if (File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // функція редагування текстових файлів
        private void EditFile(string path)
        {
            try
            {
                Process.Start("notepad.exe", path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // функція архівації файлів в ZIP
        private void ArchiveFiles(string sourcePath, string archivePath)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourcePath, archivePath);
                MessageBox.Show("Files archived successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // функція розпакування ZIP архіву
        private void UnarchiveFiles(string archivePath, string targetPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(archivePath, targetPath);
                MessageBox.Show("Files unarchived successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

