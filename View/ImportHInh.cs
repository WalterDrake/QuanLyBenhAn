using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUA_HAN.View
{
    public partial class ImportHInh : UserControl
    {
        PictureBox foundControl = new PictureBox();
        public ImportHInh(FormMain main)
        {
            InitializeComponent();
            foundControl =(PictureBox) main.Controls["pictureBox1"];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadAvatarImage(string imagePath)
        {
            // Kiểm tra xem tập tin hình ảnh có tồn tại hay không
            if (System.IO.File.Exists(imagePath))
            {
                // Tạo đối tượng hình ảnh từ tập tin
                Image image = Image.FromFile(imagePath);

                // Hiển thị hình ảnh trong PictureBox
                foundControl.Image = image;
            }
            else
            {
                // Nếu tập tin không tồn tại, hiển thị một hình ảnh mặc định hoặc thông báo lỗi
                // Ví dụ:
                pictureBox1.Image = Image.FromFile("");
                // Hoặc:
                MessageBox.Show("Không tìm thấy tập tin hình ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tập tin được chọn
                string selectedImagePath = openFileDialog.FileName;

                // Load và hiển thị ảnh đại diện trong PictureBox
                LoadAvatarImage(selectedImagePath);
            }
        }
    }
}
