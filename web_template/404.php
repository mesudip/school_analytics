<?php get_header(); ?>

<div id="content" class="clearfix">
	
	<div class="wrapper wrapper-content-main">
	
		<div class="academia-column academia-column-main academia-column-marginright">

			<div class="post-meta-single">
				<h1 class="title title-l title-post-single"><?php esc_html_e('Page not found', 'lectura-lite'); ?></h1>
			</div><!-- .post-meta-single -->

			<div class="post-single clearfix">
	
				<p><?php esc_html_e( 'Apologies, but the requested page cannot be found. Perhaps searching will help find a related page.', 'lectura-lite' ); ?></p>
				
				<div class="cleaner">&nbsp;</div>
				
				<div class="divider divider-notop">&nbsp;</div>
				
				<h3 class="title-s"><?php esc_html_e( 'Browse Categories', 'lectura-lite' ); ?></h3>
				<ul>
					<?php wp_list_categories('title_li=&hierarchical=0&show_count=1'); ?>	
				</ul>
			
				<h3 class="title-s"><?php esc_html_e( 'Monthly Archives', 'lectura-lite' ); ?></h3>
				<ul>
					<?php wp_get_archives('type=monthly&show_post_count=1'); ?>	
				</ul>
				<div class="cleaner">&nbsp;</div>
				
			</div><!-- .post-single -->	
			
			<div class="cleaner">&nbsp;</div>
		
		</div><!-- .academia-column .academia-column-main .academia-column-marginright -->
		
		<aside class="academia-column academia-column-aside academia-column-last">
		
			<?php get_sidebar(); ?>
			
			<div class="cleaner">&nbsp;</div>
		
		</aside><!-- .academia-column .academia-column-aside .academia-column-last -->
		
		<div class="cleaner">&nbsp;</div>
	
	</div><!-- .wrapper .wrapper-content-main -->

</div><!-- #content -->

<?php get_footer(); ?>