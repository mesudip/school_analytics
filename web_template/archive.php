<?php get_header(); ?>

<div id="content" class="clearfix">
	
	<div class="wrapper wrapper-content-main">
	
		<div class="academia-column academia-column-main academia-column-marginright">

			<div class="post-meta-single">
				<?php the_archive_title( '<h1 class="title title-l title-post-single">', '</h1>' ); ?>
			</div><!-- .post-meta-single -->

			<?php the_archive_description( '<div class="category-excerpt">', '</div><!-- .category-excerpt --><div class="divider">&nbsp;</div>' ); ?>

			<?php get_template_part('loop'); ?>
			
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