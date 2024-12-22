<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterExample.aspx.cs" Inherits="EmployeePortal.Examples.RepeaterExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .first {
            padding: 1pc;
        }

        .second {
            display: flex;
            justify-content: center;
            margin-bottom: 1pc;
        }

            .second img {
                width: 600%;
                height: auto;
                max-width: 600px;
                max-height: 400px;
                object-fit: cover;
            }

        .third {
            background-color: white;
            color: black;
            padding: 1pc;
        }
    </style>
</head>
<body style="background: black">
    <form id="form1" runat="server">

        <asp:Repeater ID="productGallery" runat="server">
            <ItemTemplate>
                <div class="row mb-2">
                    <div class="first">
                        <div class="second">
                            <img src='<%# Eval("ProductImage") %>' />
                            <div class="third">
                                <h1>
                                    <asp:Label runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                </h1>
                                <p>
                                     <asp:Label runat="server" Text='<%# Eval("Desc") %>'></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </form>
</body>
</html>
