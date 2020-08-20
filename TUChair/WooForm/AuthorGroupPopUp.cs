using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair.WooForm
{
    public partial class AuthorGroupPopUp : POPUP1Line
    {
        List<ComboItemVO> comboItems = null;
        private AuthorGroupVO author;
       
        public AuthorGroupVO Author
        {
            get
            {
                AuthorGroupVO pItem = new AuthorGroupVO();

                pItem.AuthorGroup_Name = txtauthoGroupName.Text;
                pItem.AuthorGroup_Explanation = txtOther.Text;
                pItem.AuthorGroup_Order = (int)numOrder.Value;
                pItem.AuthorGroup_UseOrNot = cboUseorNOt.SelectedValue.ToString();
                pItem.AuthorGroup_ID = Convert.ToInt32(this.Tag);
                //pItem.
                author = pItem;
                return author;
            }
            set
            {
                        this.Tag = value.AuthorGroup_ID;
                txtauthoGroupName.Text = value.AuthorGroup_Name;
                txtOther.Text = value.AuthorGroup_Explanation;
                numOrder.Value = value.AuthorGroup_Order;
                cboUseorNOt.SelectedValue = value.AuthorGroup_UseOrNot;
            }
        }
        public AuthorGroupPopUp()
        {
            InitializeComponent();
          
            commonService service = new commonService();
            comboItems = service.getCommonCode("사용여부@품목유형");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboUseorNOt, cList);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtauthoGroupName.Text == "")
            {
                MessageBox.Show("필수항목은 입력하셔야 합니다.");
                return;
            }
            try
            {
                AuthorService service = new AuthorService();
                if (service.SaveAuthorGroup(this.Author))
                {
                    MessageBox.Show("저장되었습니다.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("저장에 실패하였습니다.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
