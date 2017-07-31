<?php if ( post_password_required() ) : ?>
	<p class="nopassword"><?php esc_html_e( 'This post is password protected. Enter the password to view any comments.', 'lectura-lite' ); ?></p>
 	<?php
		/* Stop the rest of comments.php from being processed,
		 * but don't kill the script entirely -- we still have
		 * to fully load the template.
		 */
		return;
	endif;
?>

<?php if ( have_comments() ) : ?>

	<p class="title-m title-margin"><?php comments_number(__('No Comments','lectura-lite'), __('One Comment','lectura-lite'), __('% Comments','lectura-lite') );?></p>
 
	<?php if ( get_comment_pages_count() > 1 && get_option( 'page_comments' ) ) : // Are there comments to navigate through? ?>
		<div class="navigation clearfix">
			<?php paginate_comments_links( array('prev_text' => ''.__( '<span class="meta-nav">&larr;</span> Older Comments', 'lectura-lite' ).'', 'next_text' => ''.__( 'Newer Comments <span class="meta-nav">&rarr;</span>', 'lectura-lite' ).'') );?>
		</div> <!-- .navigation -->
	<?php endif; // check for comment navigation ?>

	<ol class="commentlist">
		<?php
			/* Loop through and list the comments. Tell wp_list_comments() to use lectura_lite_comments() to format the comments.
			 */
			wp_list_comments( array( 'callback' => 'lectura_lite_comments' ) );
		?>
	</ol><!-- .commentlist -->

	<?php if ( get_comment_pages_count() > 1 && get_option( 'page_comments' ) ) : // Are there comments to navigate through? ?>
	<div class="navigation clearfix">
		<?php paginate_comments_links( array('prev_text' => ''.__( '<span class="meta-nav">&larr;</span> Older Comments', 'lectura-lite' ).'', 'next_text' => ''.__( 'Newer Comments <span class="meta-nav">&rarr;</span>', 'lectura-lite' ).'') );?>
	</div><!-- .navigation -->
	<?php endif; // check for comment navigation ?>
 

	<?php else : // or, if we don't have comments:

		/* If there are no comments and comments are closed,
		 * let's leave a little note, shall we?
		 */
		if ( ! comments_open() ) :
	?>
		<!--<p class="title-m title-margin"><?php esc_html_e( 'Comments are closed.', 'lectura-lite' ); ?></p>-->
	<?php endif; // end ! comments_open() ?>

<?php endif; // end have_comments() ?>

<?php 
$commenter = wp_get_current_commenter();
$req = get_option( 'require_name_email' );
$aria_req = ( $req ? " aria-required='true'" : '' );


$custom_comment_form = array( 'fields' => apply_filters( 'comment_form_default_fields', array(
		'author' => 
			'<div class="form_fields">
			<p class="comment-form-author comment-form-p">' .
			'<label for="author" class="academia-comment-label">' . __( 'Your Name' , 'lectura-lite' ) . ( $req ? ' <span class="required_lab">*</span>' : '' ) . '</label> ' .
			'<input id="author" name="author" type="text" value="' . esc_attr( $commenter['comment_author'] ) . '"' . $aria_req . ' class="required academia-comment-input" />' .
			'</p>',
		'email'  => 
			'<p class="comment-form-email comment-form-p">' .
			'<label for="email" class="academia-comment-label">' . __( 'Your Email' , 'lectura-lite' ) . ( $req ? ' <span class="required_lab">*</span>' : '' ) . '</label> ' .
			'<input id="email" name="email" type="text" value="' . esc_attr(  $commenter['comment_author_email'] ) . '"' . $aria_req . ' class="required email academia-comment-input" />' .
			'</p>',
		'url'    =>  
			'<p class="comment-form-url comment-form-p">' .
			'<label for="url" class="academia-comment-label">' . __( 'Your Website' , 'lectura-lite' ) . '</label> ' .
			'<input id="url" name="url" type="text" value="' . esc_attr(  $commenter['comment_author_url'] ) . '"' . $aria_req . ' class="academia-comment-input" />' .
			'</p>
			<div class="cleaner">&nbsp;</div>
			</div><!-- .form_fields -->') ),
		'comment_field' => 
			'' .
			'<label for="comment" class="academia-comment-label">' . __( 'Comment' , 'lectura-lite' ) . '</label> ' .
			'<textarea id="comment" name="comment" rows="6" aria-required="true" class="required academia-comment-input"></textarea>' .
			'<div class="cleaner">&nbsp;</div>',
			'logged_in_as' => '<p class="logged-in-as">' . sprintf( __( 'Logged in as <a href="%1$s">%2$s</a>. <a href="%3$s">Log out?</a>', 'lectura-lite' ), admin_url( 'profile.php' ), $user_identity, wp_logout_url( apply_filters( 'the_permalink', get_permalink() ) ) ) . '</p>',
			'title_reply' => __( 'Leave a Reply' , 'lectura-lite' ),
			'cancel_reply_link' => __( 'Cancel' , 'lectura-lite' ),
			'label_submit' => __( 'Submit Comment' , 'lectura-lite' ),
			'comment_form_after' => '<div class="cleaner">&nbsp;</div>',
		);
comment_form($custom_comment_form); 
?>