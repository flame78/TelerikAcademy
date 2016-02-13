<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CachedControl.ascx.cs" Inherits="WebFormsCaching.Controls.CachedControl" %>
<%@ OutputCache Duration='3600' VaryByParam='*'%>
<div class="well">
    <p>Cached control content</p>
    Cached in <%: DateTime.UtcNow %> UTC
</div>
