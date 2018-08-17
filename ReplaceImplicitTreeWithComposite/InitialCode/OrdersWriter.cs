using System.Text;

namespace ReplaceImplicitTreeWithComposite.InitialCode
{
    public class OrdersWriter
    {
        private Orders orders;

        public OrdersWriter(Orders orders)
        {
            this.orders = orders;
        }

        public string getContents()
        {
            StringBuilder xml = new StringBuilder();
            writeOrderTo(xml);
            return xml.ToString();
        }

        private void writeOrderTo(StringBuilder xml)
        {
            xml.Append("<orders>");
            for (int i = 0; i < orders.getOrderCount(); i++)
            {
                Order order = orders.getOrder(i);
                xml.Append("<order");
                xml.Append(" id='");
                xml.Append(order.getOrderId());
                xml.Append("'>");
                writeProductsTo(xml, order);
                xml.Append("</order>");
            }
            xml.Append("</orders>");
        }

        private void writeProductsTo(StringBuilder xml, Order order)
        {
            for (int j = 0; j < order.getProductCount(); j++)
            {
                Product product = order.getProduct(j);
                xml.Append("<product");
                xml.Append(" id='");
                xml.Append(product.getId());
                xml.Append("'");
                xml.Append(" color='");
                xml.Append(colorFor(product));
                xml.Append("'");
                if (product.getSize() != productSize.NOT_APPLICABLE)
                {
                    xml.Append(" size='");
                    xml.Append(sizeFor(product));
                    xml.Append("'");
                }
                xml.Append(">");
                writePriceTo(xml, product);
                xml.Append(product.getName());
                xml.Append("</product>");
            }
        }

        private int sizeFor(Product product)
        {
            return product.getSize();
        }

        private string colorFor(Product product)
        {
            return "red";
        }

        private void writePriceTo(StringBuilder xml, Product product)
        {
            xml.Append("<price");
            xml.Append(" currency='");
            xml.Append(currencyFor(product));
            xml.Append("'>");
            xml.Append(product.getPrice());
            xml.Append("</price>");
        }

        private string currencyFor(Product product)
        {
            return "USD";
        }
    }

    internal class productSize
    {
        public static int NOT_APPLICABLE = 100;
    }
}