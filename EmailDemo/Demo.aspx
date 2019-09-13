<%@ Page Title="Download demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="EmailDemo.Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

        });

    </script>

    <div style="margin-top: 20px;">


        <fieldset>
            <legend>Text File</legend>

        <div class="container-fluid">
            <div class="row">
                <div class="col-2">
                    <a href="/api/MailMessage/TextFileTest">Download text file</a>
                </div>
                <div class="col">
                    <a href="/api/MailMessage/TextFileTest" class="btn btn-primary">Download text file</a>
                </div>
            </div>
        </div>

        </fieldset>

        <fieldset>
            <legend>Email message</legend>

        <div class="container-fluid">
            <div class="row">
                <div class="col-4">
                    <a href="/api/MailMessage/MailMessageTestAttachment">Download email message with attachment</a>
                </div>
                <div class="col">
                    <a href="/api/MailMessage/MailMessageTest" class="btn btn-primary">Download email message</a>
                </div>
            </div>
        </div>

        </fieldset>

    </div>

</asp:Content>
