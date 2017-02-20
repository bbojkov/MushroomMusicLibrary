<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- banner -->
    <div class="banner">
        <div class="container">
            <script src="js/responsiveslides.min.js"></script>
            <script>
                $(function () {
                    $("#slider").responsiveSlides({
                        auto: true,
                        nav: true,
                        speed: 500,
                        namespace: "callbacks",
                        pager: true,
                    });
                });
            </script>
            <div class="caption">
                <div class="slider">
                    <div class="callbacks_container">
                        <ul class="rslides" id="slider">
                            <li>
                                <h3>THE MUSIC WORLD</h3>
                            </li>
                            <li>
                                <h3>WORLDS BEST MUSIC</h3>
                            </li>
                        </ul>
                        <p>Which Have You Never Seen Before!!</p>
                        <a class="hvr-bounce-to-bottom morebtn" href="#">MORE</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- //banner -->
    <!-- banner-bottom -->
    <div class="banner-bottom">
        <div class="container">
            <div class="bottom-grids">

                <a href="browse/all">
                    <div class="col-md-3 bottom-one">
                        <div class="bottom-text">
                            <h3>See ALL</h3>
                            <p>Search from all bands</p>
                        </div>
                    </div>
                </a>
                <a href="browse/letter">
                    <div class="col-md-3 bottom-two">
                        <div class="bottom-text">
                            <h3>By NAME</h3>
                            <p>Search for bands alphabetically</p>
                        </div>
                    </div>
                </a>
                <a href="browse/genres">
                    <div class="col-md-3 bottom-three">
                        <div class="bottom-text">
                            <h3>By GENRE</h3>
                            <p>Search bands by genre</p>
                        </div>
                    </div>
                </a>

                <div class="col-md-3 bottom-four">
                    <div class="bottom-text">
                        <h4>SEARCH</h4>
                        <p>
                            <asp:TextBox runat="server"></asp:TextBox>
                        </p>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //banner-bottom -->
    <!-- welcome -->
    <div class="welcome">
        <div class="container">
            <div class="welcome-head">
                <h3>WELCOME</h3>
                <p>This is a course project for Telerik Academy - ASP.NET Web Forms.</p>
                <p>We Are Team Infected Mushroom</p>
                <p>If you are wondering what to listen - HERE is the place!</p>
            </div>
        </div>
    </div>
    <!-- //welcome -->

    <%--<!-- popular -->
<div class="popular">
	<div class="container">
		<div class="popular-head">
			<h3>MY ALBUM</h3>
		</div>
		<div class="popular-grids">
			<div class="col-md-4 popular-grid">
				<img src="images/111.jpg" alt=""/>
				<div class="pop-desc">
					<p>MODERN MUSIC</p>
				</div>
			</div>
			<div class="col-md-4 popular-grid">
				<img src="images/222.jpg" alt=""/>
				<div class="pop-desc">
					<p>HIP HOP MUSIC</p>
				</div>
			</div>
			<div class="col-md-4 popular-grid">
				<img src="images/333.jpg" alt=""/>
				<div class="pop-desc">
					<p>FOLK MUSIC</p>
				</div>
			</div>
			<div class="clearfix"></div>
		</div>
	</div>
</div>
<!-- //popular -->--%>

    <!-- footer -->
    <div class="footer">
        <div class="container">
            <div class="footer-grids">
                <div class="col-md-3 footer-grid">
                    <h4>ADDRESS</h4>
                    <ul>
                        <li>Music World</li>
                        <li>4111 Deer Haven Drive Greenville </li>
                        <li>SC 29601 </li>
                        <li>Hours: Mon-Fri 9am - 6:00pm</li>
                    </ul>
                </div>
                <div class="col-md-3 footer-grid">
                    <h4>GET IN TOUCH</h4>
                    <ul>
                        <li>Tel: +1 234-567-890</li>
                        <li>Fax: +1 646-216-9789</li>
                        <li>Email: <a href="mailto:info@example.com">info@yourdomain.com </a></li>
                    </ul>
                </div>

                <div class="col-md-3 footer-grid">
                    <h3><a href="index.html">MUSIC WORLD</a></h3>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //footer -->
    <!-- copy -->
    <div class="copy-right">
        <div class="container">
            <p>&copy; 2015 Music World. All Rights Reserved | Design by  <a href="http://w3layouts.com/">W3layouts</a></p>
        </div>
    </div>
    <!-- copy -->
    <!-- smooth scrolling -->
    <script type="text/javascript">
        $(document).ready(function () {
                var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear' 
                };
            $().UItoTop({ easingType: 'easeOutQuart' });
        });
    </script>
    <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>
    <!-- //smooth scrolling -->


    <!-- for bootstrap working -->
    <script src="Scripts/bootstrap.js"></script>
    <!-- //for bootstrap working -->
</asp:Content>
