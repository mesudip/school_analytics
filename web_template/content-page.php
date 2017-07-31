<?php 
$template_file = basename( get_page_template() );

if ( isset($template_file) && $template_file == 'homepage.php' ) {
	get_template_part('page-templates/homepage');
} else {

?>

		<div class="academia-column academia-column-main academia-column-marginright">

			<?php while (have_posts()) : the_post(); ?>
			
			<div class="post-meta-single">
				<h1 class="title title-l title-post-single"><?php the_title(); ?></h1>
				<?php edit_post_link( __('Edit page', 'lectura-lite'), '<p class="post-meta">', '</p>'); ?>
			</div><!-- .post-meta -->

			<div class="divider">&nbsp;</div>

			<div class="post-single">
			
				<?php the_content(); ?>
				
				<div class="cleaner">&nbsp;</div>
				
				<?php wp_link_pages(array('before' => '<p class="page-navigation"><strong>'.__('Pages', 'lectura-lite').':</strong> ', 'after' => '</p>', 'next_or_number' => 'number')); ?>
				
			</div><!-- .post-single -->
			
			<?php endwhile; ?>
			
			<div id="academia-comments">
				<?php comments_template(); ?>  
			</div><!-- #comments -->
			
			<div class="cleaner">&nbsp;</div>
		
		</div><!-- .academia-column .academia-column-main .academia-column-marginright -->
		
		<aside class="academia-column academia-column-aside academia-column-last">
		
			<?php get_sidebar(); ?>
			
			<div class="cleaner">&nbsp;</div>
		
		</aside><!-- .academia-column .academia-column-aside .academia-column-last -->
	
<?php } ?>