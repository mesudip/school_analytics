<?php
 
/*----------------------------------*/
/* Custom Posts Options				*/
/*----------------------------------*/

add_action('admin_menu', 'lectura_lite_options_box');

function lectura_lite_options_box() {
	
	add_meta_box('lectura_lite_post_template', __('Post Options','lectura-lite'), 'lectura_lite_post_options', 'post', 'side', 'high');

}

add_action('save_post', 'lectura_lite_custom_add_save');

function lectura_lite_custom_add_save($postID){
	
	// called after a post or page is saved
	if($parent_id = wp_is_post_revision($postID))
	{
		$postID = $parent_id;
	}
	
	// Check if our nonce is set.
	if ( ! isset( $_POST['lectura_lite_meta_box_nonce'] ) ) {
		return;
	}

	// Verify that the nonce is valid.
	if ( ! wp_verify_nonce( $_POST['lectura_lite_meta_box_nonce'], 'lectura_lite_meta_box' ) ) {
		return;
	}

	if (isset($_POST['save']) || isset($_POST['publish'])) {
		
		lectura_lite_update_custom_meta($postID, esc_attr($_POST['academia_post_featured']), 'academia_post_featured');
		
	}

}

function lectura_lite_update_custom_meta($postID, $newvalue, $field_name) {
	$postID = absint($postID);
	// To create new meta
	if(!get_post_meta($postID, $field_name)){
		add_post_meta($postID, $field_name, $newvalue);
	}else{
		// or to update existing meta
		update_post_meta($postID, $field_name, $newvalue);
	}
	
}

// Regular Posts Options
function lectura_lite_post_options() {
	global $post;
	wp_nonce_field( 'lectura_lite_meta_box', 'lectura_lite_meta_box_nonce' );
	?>
	<fieldset>
		<div>
			<p>
				<input class="checkbox" type="checkbox" id="academia_post_featured" name="academia_post_featured" value="on" <?php checked( get_post_meta($post->ID, 'academia_post_featured', true), 'on' ); ?> />
 				<label for="academia_post_featured"><?php _e('Feature this Post in the Homepage Slideshow','lectura-lite'); ?></label><br />
			</p>
  		</div>
	</fieldset>
	<?php
}