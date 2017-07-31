<?php
$paged = ( get_query_var('paged') ) ? get_query_var('paged') : 1;

$custom_args = array(
	'post_type' => 'post',
	'posts_per_page' => get_option ( 'posts_per_page' ),
	'paged' => absint($paged)
);

$lectura_lite_query = new WP_Query( $custom_args ); ?>

<?php if ( $lectura_lite_query->have_posts() ) : ?>
	
	<ul class="academia-posts-archive academia-loop-posts">
		
		<?php while ( $lectura_lite_query->have_posts() ) : $lectura_lite_query->the_post(); ?>
		
		<?php $classes = array('academia-post','academia-loop-post'); ?>

		<li <?php post_class($classes); ?>>
	
			<?php
			get_the_image( array( 'size' => 'lectura_lite-thumb-loop-main', 'width' => 160, 'height' => 100, 'before' => '<div class="post-cover">', 'after' => '</div><!-- .post-cover -->' ) );
			?>
			
			<div class="post-content">
				<h2 class="title-ms title-post"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'lectura-lite' ), the_title_attribute( 'echo=0' ) ); ?>"><?php the_title(); ?></a></h2>
				<p class="post-excerpt"><?php echo get_the_excerpt(); ?></p>
				<p class="post-meta"><time datetime="<?php echo get_the_date('c'); ?>" pubdate><?php echo get_the_date(); ?></time> / <span class="category"><?php the_category(', '); ?></span></p>
			</div><!-- .post-content -->
	
			<div class="cleaner">&nbsp;</div>
			
		</li><!-- .academia-post -->
		
		<?php endwhile; ?>
		
	</ul><!-- .academia-posts-archive .academia-loop-posts -->

	<?php get_template_part( 'pagination'); ?>
	
	<?php wp_reset_postdata(); ?>

<?php endif; ?>