<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Drag.ascx.cs" Inherits="UI.Admin.Drag" %>
<style type="text/css">
    body {
        margin: 0;
        padding: 0;
        background: #80BDCB;
        cursor: E-resize;
    }

    /*#img{
        background-image:url("")
    }*/
</style>

<script type="text/javascript" language="JavaScript">

    var pic = new Image();
    pic.src = "images/arrow_right.gif";

    function toggleMenu() {

        if (document.getElementById("divMenu").style.marginLeft=="-230px") {
            document.getElementById("divMenu").style.marginLeft = "0px";
            document.getElementById("divMain").style.width = "1600px";
            document.getElementById("img").src = "images/arrow_left.gif";
        } else {
            document.getElementById("divMenu").style.marginLeft = "-230px";
            document.getElementById("divMain").style.width = "1830px";
            document.getElementById("img").src = "images/arrow_right.gif";
        }

    //    if (frmBody.cols == "0, 10, *") {
    //        frmBody.cols = "200, 10, *";
    //        imgArrow.src = "images/arrow_left.gif";
    //    }
    //    else {
    //        frmBody.cols = "0, 10, *";
    //        imgArrow.src = "images/arrow_right.gif";
    //    }
    }
</script>

<div style="float:left;height:100%">
<table height="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <a href="javascript:toggleMenu();">
                <img src="images/arrow_left.gif" width="10" height="30" id="img" border="0" /></a>
        </td>
    </tr>
</table>
</div>
