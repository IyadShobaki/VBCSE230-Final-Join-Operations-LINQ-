﻿Public Class Form1
    Private Sub btnJoin2_Click(sender As Object, e As EventArgs) Handles btnJoin2.Click
        Dim dbContext As New NorthwindTablesDataContext
        Dim custOrd = From cust In dbContext.Customers
                      Join order In dbContext.Orders
                                   On cust.CustomerID Equals order.CustomerID
                      Select New With {cust.CompanyName, cust.CustomerID}
        DataGridView1.DataSource = custOrd.Distinct
        Label1.Text = DataGridView1.Rows.Count
    End Sub


    Private Sub btnGroupJoin_Click(sender As Object, e As EventArgs) Handles btnGroupJoin.Click
        Dim dbContext As New NorthwindTablesDataContext
        Dim custOrd = From cust In dbContext.Customers
                      Group Join Order In dbContext.Orders
                                   On cust.CustomerID Equals Order.CustomerID
                      Into CustOrders = Group
                      From order In CustOrders.DefaultIfEmpty
                      Where order.CustomerID Is Nothing
                      Select New With {cust.CompanyName,
                        cust.CustomerID}
        DataGridView2.DataSource = custOrd.Distinct
        Label2.Text = DataGridView2.Rows.Count
    End Sub

    Private Sub btnJoinmultiple_Click(sender As Object, e As EventArgs) Handles btnJoinmultiple.Click
        Dim dbContext As New NorthwindTablesDataContext
        DataGridView3.DataSource = From orders In dbContext.Orders
                                   Join OrderDetails In dbContext.Order_Details
                                   On orders.OrderID Equals OrderDetails.OrderID
                                   Join Product In dbContext.Products
                                   On OrderDetails.ProductID Equals Product.ProductID
                                   Where orders.CustomerID = "VINET"
                                   Select orders.CustomerID, orders.OrderDate, OrderDetails.ProductID, OrderDetails.Quantity, Product.ProductName
        Label3.Text = DataGridView3.Rows.Count
    End Sub


End Class