<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoktorRandevu.ascx.cs" Inherits="BeykentHastaRandevuSistemi.UserControls.Doktor.DoktorRandevu" %>




<div class="portlet box green">
    <div class="portlet-title">
        <div class="caption">
            <asp:Literal runat="server" Text="Hastalar" />
        </div>
        <div class="actions">
        </div>
    </div>
    <div class="portlet-body form">
        <div class="form-body kplus-fontsize-12">
            <div class="kplus-box-100">
                <div class="col-md-4">


                    <div class="col-md-12" style="margin-bottom: 20px">
                        <asp:Label ID="Label17" runat="server" Text="Poliklinik" CssClass="bold bookinga-color-claretred" />
                        <asp:DropDownList ID="drpPoliklinik" AutoPostBack="true" OnSelectedIndexChanged="drpPoliklinik_SelectedIndexChanged" DataTextField="Value" DataValueField="Key" runat="server" CssClass="form-control select2">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-12">
                    <div class="alert alert-danger" runat="server" id="dvRandevuBulunamadi" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Bugün Uygun Randevu Bulunmadı.!</span>
                </div>
                        </div>

                    <div class="table-responsive" runat="server" id="dvRandevular" visible="false">
                        <table class="table table-striped table-bordered table-advance table-hover">
                            <thead>
                                <tr>
                                    <th class="kplus-color-claretred" style="text-align: center;">Randevu Tarihi
                                    </th>
                                    <th class="kplus-color-claretred" style="text-align: center;">Hasta</th>
                                 
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptRandevular" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <%# Eval("Tarih","{0:dd.MM.yyyy HH:mm}") %>
                                            </td>
                                            <td class="text-center">
                                                <%#Eval("HastaAdi")%> 
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>

                        </table>
                    </div>
                </div>
                 <div class="col-md-3">

                     <div class="col-md-12">
                        <asp:Label ID="Label2" runat="server" Text="Randevu Oluşturacağınız Tarih" CssClass="bold bookinga-color-claretred" />

                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <asp:LinkButton ID="lnkCreateDate" runat="server" CssClass="btn col-md-12 green-dark kplus-box-color mt-ladda-btn ladda-button" data-style="zoom-in" OnClick="lnkCreateDate_Click">
                                            <i class="fa fa-check"></i> 
                                            <span class="ladda-label"><asp:Literal runat="server" Text="Randevu Saatlerini Oluştur" /></span>
                                            <span class="ladda-spinner"></span>
                        </asp:LinkButton>
                    </div>


                     </div>

                <div class="col-md-5">
                     <asp:Repeater runat="server" ID="rptRandevuTarihleri" >
                                    <ItemTemplate>
                                        <div class="col-md-4" style="margin-bottom:10px">

                                        <div  style="font-size: 16px; border: 1px solid #dadada;border-radius: 5px !important;text-align: center;padding:3px; background-color:<%# (int)Eval("RecId")==0? "" : "#ffd0d0" %>"> 
                                            <asp:HiddenField runat="server" ID="hdnRecId" Value=' <%# Eval("RecId") %>' />
                                            <asp:HiddenField runat="server" ID="hdnPoliklinikId" Value=' <%# Eval("PoliklinikId") %>' />
                                             <asp:HiddenField runat="server" ID="hdnTarih" Value=' <%# Eval("Tarih") %>' />
                                              <asp:CheckBox runat="server" ID="chbselect" Checked='<%# (int)Eval("RecId")==0? false : true %>' Enabled='<%# (int)Eval("RecId")==0? true : false %>' Text='<%# (int)Eval("RecId")==0? "Uygun" : "Dolu" %>'   /> 
                                           <br /><label><%# Eval("Saat") %></label> 
                                            
                                            </div>
                                       </div>

                                         </ItemTemplate>
                                    </asp:Repeater>


                     <div class="col-md-12">
                        <br />
                        <asp:LinkButton ID="btnRandevuOlustur" runat="server" CssClass="btn col-md-12 green-dark kplus-box-color mt-ladda-btn ladda-button" data-style="zoom-in" OnClick="btnRandevuOlustur_Click">
                                            <i class="fa fa-check"></i> 
                                            <span class="ladda-label"><asp:Literal runat="server" Text="Seçilin Saatlerde Randevu Oluştur" /></span>
                                            <span class="ladda-spinner"></span>
                        </asp:LinkButton>
                    </div>


                </div>



                <div class="clear-both"></div>
            </div>
        </div>
    </div>
</div>
