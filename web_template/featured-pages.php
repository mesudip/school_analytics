<?php if (get_theme_mod('lectura_lite_display_feat_pages') == 1) { ?>

<div class="widget clearfix">

	<?php if (get_theme_mod('lectura_lite_page_feat_1') != '' || get_theme_mod('lectura_lite_page_feat_2') != '' || get_theme_mod('lectura_lite_page_feat_3') != '') { ?>
	
	<ul class="academia-featured-pages">

		<li class="academia-featured-page academia-featured-page-1">
		
			<?php 
			if (get_theme_mod('lectura_lite_page_feat_1')) {
			$academia_loop = new WP_Query( array( 'page_id' => get_theme_mod('lectura_lite_page_feat_1') ) );
			while ( $academia_loop->have_posts() ) : $academia_loop->the_post(); global $post;
			?>
			
			<?php
			get_the_image( array( 'size' => 'lectura_lite-thumb-feat-page', 'width' => 300, 'height' => 160, 'before' => '<div class="post-cover">', 'after' => '</div><!-- .post-cover -->' ) );
			?>

			<div class="post-content">
				<div class="post-content-wrapper">
					<h2 class="title-m title-post"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'lectura-lite' ), the_title_attribute( 'echo=0' ) ); ?>"><?php the_title(); ?></a></h2>
					<p class="post-excerpt"><?php echo get_the_excerpt(); ?></p>
				</div><!-- .post-content-wrapper -->
			</div><!-- .post-content -->
			
			<?php endwhile; } ?>
			
			<div class="cleaner">&nbsp;</div>
		
		</li><!-- .academia-featured-page .academia-featured-page-1 -->

		<li class="academia-featured-page academia-featured-page-2">
		
			<?php 
			if (get_theme_mod('lectura_lite_page_feat_2')) {
			$academia_loop = new WP_Query( array( 'page_id' => get_theme_mod('lectura_lite_page_feat_2') ) );
			while ( $academia_loop->have_posts() ) : $academia_loop->the_post(); global $post;
			?>
			
			<?php
			get_the_image( array( 'size' => 'lectura_lite-thumb-feat-page', 'width' => 300, 'height' => 160, 'before' => '<div class="post-cover">', 'after' => '</div><!-- .post-cover -->' ) );
			?>

			<div class="post-content">
				<div class="post-content-wrapper">
					<h2 class="title-m title-post"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'lectura-lite' ), the_title_attribute( 'echo=0' ) ); ?>"><?php the_title(); ?></a></h2>
					<p class="post-excerpt"><?php echo get_the_excerpt(); ?></p>
				</div><!-- .post-content-wrapper -->
			</div><!-- .post-content -->
			
			<?php endwhile; } ?>
			
			<div class="cleaner">&nbsp;</div>
		
		</li><!-- .academia-featured-page .academia-featured-page-2 -->
		
		<li class="academia-featured-page academia-featured-page-3">
		
			<?php 
			if (get_theme_mod('lectura_lite_page_feat_3')) {
			$academia_loop = new WP_Query( array( 'page_id' => get_theme_mod('lectura_lite_page_feat_3') ) );
			while ( $academia_loop->have_posts() ) : $academia_loop->the_post(); global $post;
			?>
			
			<?php
			get_the_image( array( 'size' => 'lectura_lite-thumb-feat-page', 'width' => 300, 'height' => 160, 'before' => '<div class="post-cover">', 'after' => '</div><!-- .post-cover -->' ) );
			?>

			<div class="post-content">
				<div class="post-content-wrapper">
					<h2 class="title-m title-post"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'lectura-lite' ), the_title_attribute( 'echo=0' ) ); ?>"><?php the_title(); ?></a></h2>
					<p class="post-excerpt"><?php echo get_the_excerpt(); ?></p>
				</div><!-- .post-content-wrapper -->
			</div><!-- .post-content -->
			
			<?php endwhile; } ?>
			
			<div class="cleaner">&nbsp;</div>
		
		</li><!-- .academia-featured-page .academia-featured-page-3 -->
	</ul><!-- .academia-featured-pages -->
	
	<?php } ?>
	
</div><!-- .widget -->

<?php } ?>