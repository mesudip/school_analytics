<?php if (is_page() || is_page_template()) { get_template_part('related-pages'); } ?>

<?php if (is_active_sidebar('sidebar')) { ?>
	<?php
	if ( !dynamic_sidebar('Sidebar') ) : ?> <?php endif;
	?>
<?php } ?>

<div class="cleaner">&nbsp;</div>