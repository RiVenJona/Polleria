using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebPolleria
{
    public partial class GeneOrdenDelivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Div1.Visible = false;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                Div5.Visible = false;
                Div6.Visible = false;
                General3.Visible = false;
                General2.Visible = false;
                Button13.Enabled = false;
            }
        }
        public void Message(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script type = 'text/javascript'>");
            stringBuilder.Append("window.onload=function(){");
            stringBuilder.Append("alert('");
            stringBuilder.Append(str);
            stringBuilder.Append("')};");
            stringBuilder.Append("</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", stringBuilder.ToString());
        }
        protected void Total()
        {
            double a = double.Parse(LbCo1.Text);
            double b = double.Parse(LbCo2.Text);
            double c = double.Parse(LbCo3.Text);
            double d = double.Parse(LbCo4.Text);
            double e = double.Parse(LbCo5.Text);
            double f = double.Parse(LbCo6.Text);

            int cnt1 = int.Parse(Cant1.Text);
            int cnt2 = int.Parse(Cant2.Text);
            int cnt3 = int.Parse(Cant3.Text);
            int cnt4 = int.Parse(Cant4.Text);
            int cnt5 = int.Parse(Cant5.Text);
            int cnt6 = int.Parse(Cant6.Text);

            double entre = double.Parse(CostoEntrega.Text);

            double total = (a * cnt1) + (b * cnt2) + (c * cnt3) + (d * cnt4) + (e * cnt5) + (f * cnt6) + entre;

            CostoTotal3.Text = total.ToString();
            LbTotal.Text = total.ToString();
        }

        protected void Mensaje()
        {
            int cnt1 = int.Parse(Cant1.Text);
            int cnt2 = int.Parse(Cant2.Text);
            int cnt3 = int.Parse(Cant3.Text);
            int cnt4 = int.Parse(Cant4.Text);
            int cnt5 = int.Parse(Cant5.Text);
            int cnt6 = int.Parse(Cant6.Text);

            if (cnt1 == 0 && cnt2 == 0 && cnt3 == 0 && cnt4 == 0 && cnt5 == 0 && cnt3 == 0)
            {
                MensajeVacio.Visible = true;
                Button13.Enabled = false;
                CostoEntrega.Text = 0.00.ToString();
            }
        }
        protected void Incrementar1()
        {
            int a1 = int.Parse(Cant1.Text) + 1;
            Cant1.Text = a1.ToString();
        }
        protected void Incrementar2()
        {
            int a2 = int.Parse(Cant2.Text) + 1;
            Cant2.Text = a2.ToString();
        }
        protected void Incrementar3()
        {
            int a3 = int.Parse(Cant3.Text) + 1;
            Cant3.Text = a3.ToString();
        }
        protected void Incrementar4()
        {
            int a4 = int.Parse(Cant4.Text) + 1;
            Cant4.Text = a4.ToString();
        }
        protected void Incrementar5()
        {
            int a5 = int.Parse(Cant5.Text) + 1;
            Cant5.Text = a5.ToString();
        }
        protected void Incrementar6()
        {
            int a6 = int.Parse(Cant6.Text) + 1;
            Cant6.Text = a6.ToString();
        }

        protected void Decrecer1()
        {
            int a1 = int.Parse(Cant1.Text) - 1;
            Cant1.Text = a1.ToString();
        }
        protected void Decrecer2()
        {
            int a2 = int.Parse(Cant2.Text) - 1;
            Cant2.Text = a2.ToString();
        }
        protected void Decrecer3()
        {
            int a3 = int.Parse(Cant3.Text) - 1;
            Cant3.Text = a3.ToString();
        }
        protected void Decrecer4()
        {
            int a4 = int.Parse(Cant4.Text) - 1;
            Cant4.Text = a4.ToString();
        }
        protected void Decrecer5()
        {
            int a5 = int.Parse(Cant5.Text) - 1;
            Cant5.Text = a5.ToString();
        }
        protected void Decrecer6()
        {
            int a6 = int.Parse(Cant6.Text) - 1;
            Cant6.Text = a6.ToString();
        }

        protected void Btn1_Click(object sender, EventArgs e)
        {
            Div1.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant1.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void Btn2_Click(object sender, EventArgs e)
        {
            Div2.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant2.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void Btn3_Click(object sender, EventArgs e)
        {
            Div3.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant3.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void Btn4_Click(object sender, EventArgs e)
        {
            Div4.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant4.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void Btn5_Click(object sender, EventArgs e)
        {
            Div5.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant5.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void Btn6_Click(object sender, EventArgs e)
        {
            Div6.Visible = true;
            MensajeVacio.Visible = false;
            Button13.Enabled = true;
            Cant6.Text = 1.ToString();
            CostoEntrega.Text = 6.50.ToString();
            Total();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Div1.Visible = false;
            Cant1.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Div2.Visible = false;
            Cant2.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Div3.Visible = false;
            Cant3.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Div4.Visible = false;
            Cant4.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Div5.Visible = false;
            Cant5.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Div6.Visible = false;
            Cant6.Text = 0.ToString();
            Mensaje();
            Total();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Incrementar1();
            Total();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Decrecer1();
            Total();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Incrementar2();
            Total();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Decrecer2();
            Total();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Incrementar3();
            Total();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Decrecer3();
            Total();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Incrementar4();
            Total();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Decrecer4();
            Total();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Incrementar5();
            Total();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Decrecer5();
            Total();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Incrementar6();
            Total();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Decrecer6();
            Total();
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            General1.Visible = false;
            General2.Visible = true;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            General1.Visible = true;
            General2.Visible = false;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton4.Checked = false;
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton3.Checked = false;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            if (RadioButton3.Checked)
            {
                Message("Pedido realizado satisfactoriamente");
            }
            else if (RadioButton4.Checked)
            {
                General2.Visible = false;
                General3.Visible = true;
            }
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Message("Pedido realizado satisfactoriamente");
        }
    }
}