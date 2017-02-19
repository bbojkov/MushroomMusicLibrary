<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="MusicLibrary.Web.Account.account" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Search Section</h4>
                    </div>
                    <div class="modal-body">


                        <section class="search-box1" id="panel">
                            <div class="container">
                                <form class="form-inline" role="form">
                                    <div class="col-sm-8 col-xs-8 form-group top_search" style="padding-right: 0px;">
                                        <div class="row">
                                            <label class="sr-only" for="search">Search here...</label>
                                            <span class="serach-footer">
                                                <img src="images/srch.png" /></span>
                                            <input type="text" class="form-control search-wrap" id="search" placeholder="Search here...">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 col-xs-4 form-group top_search" style="padding-left: 0px;">
                                            <button type="submit" class="btn btn-default search-btn">SEARCH</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </section>


                    </div>

                </div>
            </div>

        </div>
    </div>
    <br>
    <br>
    <br>

    <section>
        <div class="container" style="margin-top: 30px;">
            <div class="profile-head">
                <div class="col-md- col-sm-4 col-xs-12">
                    <img src="http://www.newlifefamilychiropractic.net/wp-content/uploads/2014/07/300x300.gif" class="img-responsive" />
                    <h6>Jenifer Smith</h6>
                </div>
                <!--col-md-4 col-sm-4 col-xs-12 close-->
                <div class="col-md-5 col-sm-5 col-xs-12">
                    <h5>Jenifer Smith</h5>
                    <p>Web Designer / Develpor </p>
                    <ul>
                        <li><span class="glyphicon glyphicon-briefcase"></span>5 years</li>
                        <li><span class="glyphicon glyphicon-map-marker"></span>U.S.A.</li>
                        <li><span class="glyphicon glyphicon-home"></span>555 street Address,toedo 43606 U.S.A.</li>
                        <li><span class="glyphicon glyphicon-phone"></span><a href="#" title="call">(+021) 956 789123</a></li>
                        <li><span class="glyphicon glyphicon-envelope"></span><a href="#" title="mail">jenifer123@gmail.com</a></li>

                    </ul>


                </div>
                <!--col-md-8 col-sm-8 col-xs-12 close-->




            </div>
            <!--profile-head close-->
        </div>
        <!--container close-->


        <div id="sticky" class="container">

            <!-- Nav tabs -->
            <ul class="nav nav-tabs nav-menu" role="tablist">
                <li class="active">
                    <a href="#profile" role="tab" data-toggle="tab">
                        <i class="fa fa-male"></i>Profile
                    </a>
                </li>
                <li>
                    <a href="#change" role="tab" data-toggle="tab">
                        <i class="fa fa-key"></i>Edit Profile
                    </a>
                </li>
                <li>
                    <a href="#collection" role="tab" data-toggle="tab">
                        <i class="fa fa-key"></i>Your collection
                    </a>
                </li>
            </ul>
            <!--nav-tabs close-->

            <!-- Tab panes -->
            <div class="tab-content">
                <div class="tab-pane fade active in" id="profile">
                    <div class="container">
                        <div class="col-sm-11" style="float: left;">
                            <div class="hve-pro">
                                <p>
                                    Hello I’m Jenifer Smith, a leading expert in interactive and creative design specializing in the mobile medium. 
My graduation from Massey University with a Bachelor of Design majoring in visual communication.
                                </p>
                            </div>
                            <!--hve-pro close-->
                        </div>
                        <!--col-sm-12 close-->
                        <br clear="all" />
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="pro-title">Bio Graph</h4>
                            </div>
                            <!--col-md-12 close-->


                            <div class="col-md-6">

                                <div class="table-responsive responsiv-table">
                                    <table class="table bio-table">
                                        <tbody>
                                            <tr>
                                                <td>Firstname</td>
                                                <td>: jenifer</td>
                                            </tr>
                                            <tr>
                                                <td>Lastname</td>
                                                <td>: smith</td>
                                            </tr>
                                            <tr>
                                                <td>Birthday</td>
                                                <td>: 10 january 1980</td>
                                            </tr>
                                            <tr>
                                                <td>Contury</td>
                                                <td>: U.S.A.</td>
                                            </tr>
                                            <tr>
                                                <td>Occupation</td>
                                                <td>: Web Designer</td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                                <!--table-responsive close-->
                            </div>
                            <!--col-md-6 close-->

                            <div class="col-md-6">

                                <div class="table-responsive responsiv-table">
                                    <table class="table bio-table">
                                        <tbody>
                                            <tr>
                                                <td>Emai Id</td>
                                                <td>: jenifer123@gmail.com</td>
                                            </tr>
                                            <tr>
                                                <td>Mobile</td>
                                                <td>: (+6283) 456 789</td>
                                            </tr>
                                            <tr>
                                                <td>Phone</td>
                                                <td>: (+021) 956 789123</td>
                                            </tr>
                                            <tr>
                                                <td>Experience</td>
                                                <td>: 5 years</td>
                                            </tr>
                                            <tr>
                                                <td>Twiter</td>
                                                <td>#@jenifer123</td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                                <!--table-responsive close-->
                            </div>
                            <!--col-md-6 close-->

                        </div>
                        <!--row close-->




                    </div>
                    <!--container close-->
                </div>
                <!--tab-pane close-->


                <div class="tab-pane fade" id="change">
                    <div class="container fom-main">
                        <div class="row">
                            <div class="col-sm-12">
                                <h2 class="register">Edit Your Profile</h2>
                            </div>
                            <!--col-sm-12 close-->

                        </div>
                        <!--row close-->
                        <br />
                        <div class="row">

                            <form class="form-horizontal main_form text-left" action=" " method="post" id="contact_form">
                                <fieldset>


                                    <div class="form-group col-md-12">
                                        <label class="col-md-10 control-label">First Name</label>
                                        <div class="col-md-12 inputGroupContainer">
                                            <div class="input-group">
                                                <input name="first_name" placeholder="First Name" class="form-control" type="text">
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Text input-->

                                    <div class="form-group col-md-12">
                                        <label class="col-md-10 control-label">Last Name</label>
                                        <div class="col-md-12 inputGroupContainer">
                                            <div class="input-group">
                                                <input name="last_name" placeholder="Last Name" class="form-control" type="text">
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Text input-->

                                    <div class="form-group col-md-12">
                                        <label class="col-md-10 control-label">Phone #</label>
                                        <div class="col-md-12 inputGroupContainer">
                                            <div class="input-group">
                                                <input name="phone" placeholder="(845)555-1212" class="form-control" type="text">
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Button -->
                                    <div class="form-group col-md-10">
                                        <div class="col-md-6">
                                            <button type="submit" class="btn btn-warning submit-button">Save</button>
                                            <button type="submit" class="btn btn-warning submit-button">Cancel</button>

                                        </div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                        <!--row close-->
                    </div>
                    <!--container close -->
                </div>
                <!--tab-pane close-->

                <div class="tab-pane fade" id="collection">
                    <div class="container fom-main">
                        <div class="row">
                            <div class="col-sm-12">
                                <h2 class="register">Your favorite bands</h2>
                                <div class="row">
                                    <!--col-md-12 close-->
                                    <div class="col-md-6">

                                        <div class="table-responsive responsiv-table">
                                            <table class="table bio-table">
                                                <%-- HERE IS THE PLACE FOR ALL LIKED BANDS --%>

                                            </table>
                                        </div>
                                        <!--table-responsive close-->
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
            <!--tab-content close-->
        </div>
        <!--container close-->

    </section>
    <!--section close-->


</asp:Content>
