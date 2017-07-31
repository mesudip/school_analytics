<?php get_header(); ?>

<div id="content" class="clearfix">
	
	<div class="wrapper wrapper-content-main">
	
		<?php if ( !is_home() || is_front_page() ) { get_template_part('slideshow', 'home'); } ?>

		<?php
		if ( !dynamic_sidebar('Homepage Content: Main') ) : ?> <?php endif;
		?>

		<?php get_template_part('loop', 'archives'); ?>
		
		<div class="cleaner">&nbsp;</div>
	
	</div><!-- .wrapper .wrapper-content-main -->

</div><!-- #content -->

<?php get_footer(); ?>