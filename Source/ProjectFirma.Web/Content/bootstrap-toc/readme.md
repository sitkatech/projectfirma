<!---LINK TO TOC FUNCTION-->

<script src="@Url.Content("~/Content/bootstrap-toc/bootstrap-toc.min.js")" type="text/javascript"></script>


<!---HTML STRUCTURE FOR AFFIXED SIDEBAR WITH DYNAMICALLY CREATED TOC-->

<div data-spy="scroll" data-target="#toc">
  <!-- scope of page for table of contents -->
  <div id="contentForTOC">
    <div class="row">
      <!-- sidebar, which will move to the top on a small screen -->
      <div data-target="#tableofcontents" id="scrollSpyContent" class="col-lg-2 col-md-3 hidden-sm hidden-xs hidden-print">
            <nav id="tableOfContents" data-spy="affix" data-offset-top="#" class="scrollSpy"></nav>
        </div>
      <!-- main content area -->
      <div class="col-sm-9">
          <!-- top level is the highest header value -->
          <h4></h4> 
          <!-- lower levels are nested on TOC -->
          <h5></h5>
          <h4></h4>
          <!-- to add an item to TOC without producing a header style like so: -->
          <h4 data-toc-text="Text for TOC" style="display: none"></h4>
          <h4></h4>
          <h5></h5>
          <!-- to produce a header style withou adding it to the TOC style like so: -->
          <h4 data-toc-skip class="panel-title">Header Title</h4>
          <h4></h4>
      </div>
    </div>
  </div>
</div>


<!---JAVASCRIPT FOR SCROLLSPY AND TOC-->

<script type="text/javascript">
    jQuery(document)
        .ready(function () {

            var navSelector = '#tableOfContents';
            var navContents = '#contentForTOC';
            var $myNav = jQuery(navSelector);
            var $navContent = jQuery(navContents);

            Toc.init({
                $nav: $myNav,
                $scope: $navContent
            });
            jQuery('body').scrollspy({
                target: navSelector
            });
        });
</script>


<!---CSS FOR STYLING SIDEBAR-->

        nav#tableOfContents ul.nav
        {
            background: #ffffff;
        }

        nav#tableOfContents ul.nav li a
        {
            margin: 0;
            padding: 8px 16px;
            border: none;
            background-color: transparent;
            border-radius: 0;
            color: #555;
            text-decoration: none;
        }

        nav#tableOfContents ul.nav li a:hover, nav#tableOfContents ul.nav li ul.nav li a:hover
        {
            color: #0066cc;
            cursor: pointer;
            text-decoration: none;
            background-color: #eee;
        }

        nav#tableOfContents ul.nav li.active a, nav#tableOfContents ul.nav li.active ul.nav li.active a
        {
            color: #fff;
            background: @ViewDataTyped.ThresholdEvaluation.ThresholdIndicator.ThresholdReportingCategory.ThresholdCategory.ThemeColor;
            border: none;
            cursor: pointer;

        }

        nav#tableOfContents ul.nav li.active ul.nav li a
        {
            color: #0066cc;
            cursor: pointer;
            text-decoration: none;
            background-color: #eee;
        }

        nav#tableOfContents ul.nav li.active ul.nav li a
        {
            color: #555;
            background: transparent;
            cursor: pointer;
        }


        .scrollSpy
        {
            width: 220px;
            padding: 0px 16px;
        }

        .scrollSpy.affix
        {
            top: 117px;
        }