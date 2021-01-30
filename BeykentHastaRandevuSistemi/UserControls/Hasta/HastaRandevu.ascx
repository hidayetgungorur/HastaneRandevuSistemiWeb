<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HastaRandevu.ascx.cs" Inherits="BeykentHastaRandevuSistemi.UserControls.Hasta.HastaRandevu" %>

<style>
    .nav-tabs > li.active > a {
        font-size: 18px;
        font-weight: bold;
    }

</style>

<div class="portlet box green">
    <div class="portlet-title">
        <div class="caption">
            <asp:Literal runat="server" Text="Randevu Al" />
        </div>
        <div class="actions">
        </div>
    </div>
    <div class="portlet-body form">
        <div class="form-body kplus-fontsize-12">
            <div class="kplus-box-100">

                <div class="col-md-4">
                    <div class="col-md-9" style="margin-bottom: 20px">
                        <asp:Label ID="Label17" runat="server" Text="Poliklinik" CssClass="bold bookinga-color-claretred" />
                        <asp:DropDownList ID="drpPoliklinik" AutoPostBack="true" OnSelectedIndexChanged="drpPoliklinik_SelectedIndexChanged" DataTextField="Value" DataValueField="Key" runat="server" CssClass="form-control select2">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-9" style="margin-bottom: 20px">
                        <asp:Label ID="Label1" runat="server" Text="Doktor" CssClass="bold bookinga-color-claretred" />
                        <asp:DropDownList ID="drpDoktor" DataTextField="Value" DataValueField="Key" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-9" style="margin-bottom: 20px">
                        <asp:Label ID="Label2" runat="server" Text="Randevu Tarihi" CssClass="bold bookinga-color-claretred" />

                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </div>
                    <div class="col-md-9">
                        <br />
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn col-md-12  green-dark kplus-box-color mt-ladda-btn ladda-button" data-style="zoom-in" OnClick="lnkSearch_Click">
                                            <i class="fa fa-search"></i> 
                                            <span class="ladda-label"><asp:Literal runat="server" Text="Randevu Ara" /></span>
                                            <span class="ladda-spinner"></span>
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="col-md-8">

                    

                    <div class="portlet light ">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-social-dribbble font-purple-soft"></i>
                                <span class="caption-subject font-purple-soft bold uppercase">Müsait Randevular</span>
                            </div>
                        </div>
                        <div class="portlet-body">
                             <div class="alert alert-danger" runat="server" id="dvRandevuBulunamadi" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Seçilin Tarihte Uygun Randevu Bulunmadı.!</span>
                </div>


                            <ul class="nav nav-tabs" style="margin-bottom:0px !important">
                                <asp:Repeater runat="server" ID="rptHeader">
                                    <ItemTemplate>

                                <li class="">
                                    <a href="#tab_1_1<%# Container.ItemIndex  %>" data-toggle="tab"><%# Eval("Tarih","{0:dd.MM.yyyy}") %> </a>
                                </li>
                                </ItemTemplate>
                                    </asp:Repeater>
                            </ul>
                            <div class="tab-content">
                                 <asp:Repeater runat="server" ID="rptList">
                                    <ItemTemplate>
                                <div class="tab-pane fade  in" id="tab_1_1<%# Container.ItemIndex  %>">
                                    <p>
                                        <asp:Repeater runat="server" ID="rptListItem" DataSource='<%# Eval("Items") %>'>
                                    <ItemTemplate>
                                        <div class="col-md-3" style="margin-bottom:10px;">

                                        <div  style="font-size: 16px; border: 1px solid #dadada;border-radius: 5px !important;text-align: center;padding:3px; background-color:<%# (int)Eval("HastaId")==0? "" : "#ffd0d0" %>"> 
                                            <asp:HiddenField runat="server" ID="hdnRecId" Value=' <%# Eval("RecId") %>' />
                                              <asp:CheckBox runat="server" ID="chbselect" Checked='<%# (int)Eval("HastaId")==0? false : true %>' Enabled='<%# (int)Eval("HastaId")==0? true : false %>' Text='<%# (int)Eval("HastaId")==0? "Uygun" : "Dolu" %>'   /> 
                                           <br /><label><%# Eval("Saat") %></label> 
                                            
                                            </div>
                                       </div>

                                         </ItemTemplate>
                                    </asp:Repeater>
                                    </p>
                                </div>
                                         </ItemTemplate>
                                    </asp:Repeater>
                                         <div class="clear-both"></div>
                            </div>
                            <div class="clearfix margin-bottom-20"></div>
                        </div>
                    </div>

                     <div class="col-md-12">
                <div class="alert alert-success" runat="server" id="dvRandevuBasarili" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Randevunuz Oluşturulmuştur.</span>
                </div>
                <div class="alert alert-danger" runat="server" id="dvRandevuHata" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Lütfen Uygun Randevuyu Seçiniz.</span>
                </div>
                     </div>

                <div class="col-md-4">
                        <asp:Button ID="btnRandevuKaydet" Visible="false" runat="server" Text="Seçili Randevuyu Kaydet" CssClass="btn col-md-12  green-dark kplus-box-color mt-ladda-btn ladda-button" data-style="zoom-in" OnClick="btnRandevuKaydet_Click">
                                           
                        </asp:Button>

                </div>
                </div>
                

                <div class="clear-both"></div>
            </div>




        </div>
    </div>
</div>
