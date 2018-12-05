
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dbContext As New testDataContext
        DataGridView1.DataSource = From orders In dbContext.Orders
                                   Join OrderDetails In dbContext.Order_Details
                                   On orders.OrderID Equals OrderDetails.OrderID
                                   Join Product In dbContext.Products
                                   On OrderDetails.ProductID Equals Product.ProductID
                                   Where orders.CustomerID = "VINET"
                                   Select orders.CustomerID, orders.OrderDate, OrderDetails.ProductID, OrderDetails.Quantity, Product.ProductName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dbContext As New testDataContext
        Dim custOrd = From cust In dbContext.Customers
                      Group Join Order In dbContext.Orders
                                   On cust.CustomerID Equals Order.CustomerID
                      Into CustOrders = Group
                      From order In CustOrders.DefaultIfEmpty
                      Where order.CustomerID Is Nothing
                      Select New With {cust.CompanyName,
                        cust.CustomerID}
        DataGridView1.DataSource = custOrd.Distinct
    End Sub
End Class
