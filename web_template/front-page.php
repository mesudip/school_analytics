<?php
if ( 'posts' == get_option( 'show_on_front' ) ) :

	get_template_part( 'index' );

else :

?>

	<?php get_header(); ?>

<div id="content" class="clearfix">
	
	<div class="wrapper wrapper-content-main clearfix">
	
		<?php get_template_part('slideshow', 'home'); ?>

		<?php if (get_theme_mod('lectura_lite_display_feat_pages') == 1) { ?>

			<?php get_template_part('featured-pages');?>

		<?php } ?>

		<?php
		if ( !dynamic_sidebar('Homepage Content: Main') ) : ?> <?php endif;
		?>

		<?php if (is_active_sidebar('home-col-1') || is_active_sidebar('home-col-2')) { ?>
		
		<div class="academia-column academia-column-half academia-column-marginright clearfix">
		
			<?php
			if ( !dynamic_sidebar('Homepage Content: Left Column') ) : ?> <?php endif;
			?>
			
			<div class="cleaner">&nbsp;</div>
		
		</div><!-- .academia-column .academia-column-half -->
		
		<div class="academia-column academia-column-half academia-column-last clearfix">
		
		<?php
			if ( !dynamic_sidebar('Homepage Content: Right Column') ) : ?> <?php endif;
			?>
			
			<div class="cleaner">&nbsp;</div>
		
		</div><!-- .academia-column .academia-column-half -->
		
		<?php } ?>
		
		<div class="cleaner">&nbsp;</div>
	
		<?php
			
			get_template_part('content', 'page');
		
		?>

	</div><!-- .wrapper .wrapper-content-main -->

</div><!-- #content -->

<?php get_footer(); ?>

<?php endif; ?>