<?php
global $wp_query;

if ($wp_query->max_num_pages > 1) { ?>
<div class="navigation">
	<?php
		$big = 999999999; // need an unlikely integer

		echo paginate_links( array(
			'base' => str_replace( $big, '%#%', get_pagenum_link( $big ) ),
			'format' => '?paged=%#%',
			'current' => max( 1, get_query_var('paged') ),
			'total' => $wp_query->max_num_pages,
			'prev_text'    => __('&larr; Previous', 'lectura-lite'),
			'next_text'    => __('Next &rarr;', 'lectura-lite')
		 ) );
		?>
</div><!-- .navigation -->
<?php } ?>
