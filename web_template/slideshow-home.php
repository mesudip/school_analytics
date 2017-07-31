<?php if (get_theme_mod('lectura_lite_display_slideshow') == 1 || get_theme_mod('lectura_lite_page_slideshow') != '') {

$academia_loop = new WP_Query( array( 
	'order'          => 'DESC',
	'orderby'          => 'date',
	'post__not_in' => get_option( 'sticky_posts' ),
	'posts_per_page' => absint(get_theme_mod('lectura_lite_slideshow_number'), 5),
	'meta_key' => 'academia_post_featured',
	'meta_value' => 'on'
) );

$default_image = esc_url( get_template_directory_uri() ) . '/images/x.gif';

if ($academia_loop->have_posts()) { ?>

<div id="academia-slideshow" class="flexslider widget">
	<ul class="academia-slides">

		<?php while ( $academia_loop->have_posts() ) : $academia_loop->the_post();

		if ( has_post_thumbnail() ) : ?>
		<li class="academia-slide">
			<div class="post-cover">
				<a href="<?php the_permalink(); ?>" title="<?php the_title_attribute(); ?>">
				<?php the_post_thumbnail('lectura_lite-thumb-slideshow'); ?>
				</a>
			</div><!-- .post-cover -->
			
			<div class="post-content">
				<div class="post-content-wrapper">
					<?php the_title( sprintf( '<h2 class="title-l title-post"><a href="%s" rel="bookmark">', esc_url( get_permalink() ) ), '</a></h2>' ); ?>
					<p class="post-excerpt"><?php echo get_the_excerpt(); ?></p>
					<span class="read-more-span"><a class="read-more-anchor" href="<?php echo esc_url(get_permalink()); ?>"><?php esc_html_e('Continue Reading','lectura-lite'); ?></a></span>
				</div><!-- .post-content-wrapper -->
			</div><!-- .post-content -->
			
		</li><!-- .slide -->
		<?php endif; ?>

		<?php endwhile; ?>

	</ul><!-- .academia-slides -->
</div><!-- #academia-slideshow .flexslider -->
<?php }
elseif (!$academia_loop->have_posts() && current_user_can('edit_theme_options')) { ?>
<div class="widget"><p class="academia-notice">
	<?php esc_html_e('Please mark some posts as "Featured" for the Homepage Slideshow.','lectura-lite'); ?>
	<br />
	<?php esc_html_e('For more information please','lectura-lite'); ?> <a href="http://www.academiathemes.com/documentation/lectura-lite/"><?php esc_html_e('read the documentation','lectura-lite'); ?></a></p></div>
<?php }
} // if slideshow enabled on Customize screen 
?>