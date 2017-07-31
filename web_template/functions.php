<?php			

if ( ! isset( $content_width ) ) $content_width = 630;

/* Disable PHP error reporting for notices, leave only the important ones 
================================== */

// error_reporting(E_ERROR | E_PARSE);

/* Add javascripts and CSS used by the theme 
================================== */

function lectura_lite_scripts_styles() {

	// Loads our main stylesheet
	wp_enqueue_style( 'lectura_lite-style', get_stylesheet_uri(), array(), '2015-08-01' );
	
	if (! is_admin()) {

		wp_enqueue_script(
			'superfish',
			get_template_directory_uri() . '/js/superfish.js',
			array('jquery'),
			null,
			true
		);
		
		wp_enqueue_script(
			'lectura_lite-init',
			get_template_directory_uri() . '/js/init.js',
			array('jquery'),
			null,
			true
		);

		wp_enqueue_script(
			'flexslider',
			get_template_directory_uri() . '/js/jquery.flexslider.js',
			array('jquery'),
			null,
			true
		);
		
		if ( is_front_page() || is_home() ) {
			wp_enqueue_script(
				'lectura_lite-init-slider',
				get_template_directory_uri() . '/js/init-slider.js',
				array('jquery','flexslider'),
				null,
				true
			);
		}

		if ( is_singular() && comments_open() && get_option( 'thread_comments' ) )
		wp_enqueue_script( 'comment-reply' );

		// Loads our default Google Webfont
		wp_enqueue_style( 'lectura_lite-webfonts', '//fonts.googleapis.com/css?family=Open+Sans:400,600,700', array() );

		// Load the html5 shiv.
		wp_enqueue_script( 'html5', get_theme_file_uri( '/js/html5.js' ), array(), '3.7.3' );
		wp_script_add_data( 'html5', 'conditional', 'lt IE 9' );

	}

}
add_action('wp_enqueue_scripts', 'lectura_lite_scripts_styles');

/**
 * Sets up theme defaults and registers the various WordPress features that Lectura Lite supports.
 *
 * @return void
 */

function lectura_lite_setup() {

	/* Register Thumbnails Size 
	================================== */
	
	add_image_size( 'lectura_lite-thumb-slideshow', 960, 350, true );
	add_image_size( 'lectura_lite-thumb-feat-page', 300, 160, true );
	add_image_size( 'lectura_lite-thumb-loop-main', 160, 100, true );
	
	/* 	Register Custom Menu 
	==================================== */
	
	register_nav_menu('primary', __('Main Menu', 'lectura-lite'));
	register_nav_menu('secondary', __('Secondary (Top) Menu', 'lectura-lite'));

	/* Add support for Localization
	==================================== */
	
	load_theme_textdomain( 'lectura-lite', get_template_directory() . '/languages' );
	
	$locale = get_locale();
	$locale_file = get_template_directory() . "/languages/$locale.php";
	if ( is_readable($locale_file) )
		require_once($locale_file);
	
	/* Add support for Custom Background 
	==================================== */
	
	add_theme_support( 'custom-background' );
	
	/* Add support for post and comment RSS feed links in <head>
	==================================== */
	
	add_theme_support( 'automatic-feed-links' ); 
	
	/*
	 * Let WordPress manage the document title.
	 * By adding theme support, we declare that this theme does not use a
	 * hard-coded <title> tag in the document head, and expect WordPress to
	 * provide it for us.
	 */
	add_theme_support( 'title-tag' );

	// This theme styles the visual editor to resemble the theme style.
	add_editor_style( array( 'css/editor-style.css' ) );

}

add_action( 'after_setup_theme', 'lectura_lite_setup' );

/**
 * Registers one widget area.
 *
 * @return void
 */

function lectura_lite_widgets_init() {

	register_sidebar(array(
	'name'=> __('Sidebar','lectura-lite'),
	'id' => 'sidebar',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-s title-widget title-widget-grey">',
	'after_title' => '</p>',
	));

	/*----------------------------------*/
	/* Homepage					 		*/
	/*----------------------------------*/
	 
	register_sidebar(array(
	'name'=> __('Sidebar','lectura-lite'),
	'id' => 'home-main',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-s title-widget title-widget-blue">',
	'after_title' => '</p>',
	));

	register_sidebar(array(
	'name'=> __('Homepage Content: Left Column','lectura-lite'),
	'id' => 'home-col-1',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-s title-widget title-widget-blue">',
	'after_title' => '</p>',
	));

	register_sidebar(array(
	'name'=> __('Homepage Content: Right Column','lectura-lite'),
	'id' => 'home-col-2',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-s title-widget title-widget-blue">',
	'after_title' => '</p>',
	));

	/*----------------------------------*/
	/* Footer					 		*/
	/*----------------------------------*/
	 
	register_sidebar(array('name'=> __('Footer: Column 1','lectura-lite'),
	'id' => 'footer-col-1',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-widget">',
	'after_title' => '</p>',
	));

	register_sidebar(array('name'=> __('Footer: Column 2','lectura-lite'),
	'id' => 'footer-col-2',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-widget">',
	'after_title' => '</p>',
	));

	register_sidebar(array('name'=> __('Footer: Column 3','lectura-lite'),
	'id' => 'footer-col-3',
	'before_widget' => '<div class="widget %2$s" id="%1$s">',
	'after_widget' => '<div class="cleaner">&nbsp;</div></div>',
	'before_title' => '<p class="title-widget">',
	'after_title' => '</p>',
	));

}

add_action( 'widgets_init', 'lectura_lite_widgets_init' );

/* Enable Excerpts for Static Pages
==================================== */

add_action( 'init', 'lectura_lite_excerpts_for_pages' );

function lectura_lite_excerpts_for_pages() {
	add_post_type_support( 'page', 'excerpt' );
}

/* Custom Excerpt Length
==================================== */

function lectura_lite_new_excerpt_length($length) {
	return 35;
}
add_filter('excerpt_length', 'lectura_lite_new_excerpt_length');

/* Replace invalid ellipsis from excerpts
==================================== */

function lectura_lite_excerpt($text)
{
   return str_replace('[...]', '...', $text);
}
add_filter('the_excerpt', 'lectura_lite_excerpt');

/* Reset [gallery] shortcode styles						
==================================== */

add_filter('gallery_style', create_function('$a', 'return "<div class=\'gallery\'>";'));


/* Custom Pagination for the Blog page template						
==================================== */

function lectura_lite_pagination($numpages = '', $pagerange = '', $paged='') {

	if (empty($pagerange)) {
		$pagerange = 2;
	}
	
	/**
	* This first part of our function is a fallback
	* for custom pagination inside a regular loop that
	* uses the global $paged and global $wp_query variables.
	* 
	* It's good because we can now override default pagination
	* in our theme, and use this function in default quries
	* and custom queries.
	*/
	global $paged;
	if (empty($paged)) {
		$paged = 1;
	}
	if ($numpages == '') {
		global $wp_query;
		$numpages = $wp_query->max_num_pages;
		if(!$numpages) {
			$numpages = 1;
		}
	}
	
	/** 
	* We construct the pagination arguments to enter into our paginate_links
	* function. 
	*/
	$pagination_args = array(
		'base'            => get_pagenum_link(1) . '%_%',
		'format'          => 'page/%#%',
		'total'           => absint($numpages),
		'current'         => absint($paged),
		'show_all'        => False,
		'end_size'        => 1,
		'mid_size'        => $pagerange,
		'prev_next'       => True,
		'prev_text'       => __('&laquo;','lectura-lite'),
		'next_text'       => __('&raquo;','lectura-lite'),
		'type'            => 'plain',
		'add_args'        => false,
		'add_fragment'    => ''
	);
	
	$paginate_links = paginate_links($pagination_args);
	
	if ($paginate_links) {
		echo "<nav class='custom-pagination'>";
		echo "<span class='page-numbers page-num'>";
		echo __('Page','lectura-lite') . " $paged " . __('of','lectura-lite') . " $numpages ";
		echo "</span>";
		echo $paginate_links;
		echo "</nav>";
	}

}

/* Comments Custom Template						
==================================== */

function lectura_lite_comments( $comment, $args, $depth ) {
	$GLOBALS['comment'] = $comment;
	switch ( $comment->comment_type ) :
		case '' :
			?>
			<li <?php comment_class(); ?> id="li-comment-<?php comment_ID(); ?>">
				<div id="comment-<?php comment_ID(); ?>">
				
					<div class="comment-author vcard">
						<?php echo get_avatar( $comment, 50 ); ?>

						<div class="reply">
							<?php comment_reply_link( array_merge( $args, array( 'depth' => $depth, 'max_depth' => $args['max_depth'] ) ) ); ?>
						</div><!-- .reply -->

					</div><!-- .comment-author .vcard -->
	
					<div class="comment-body">
	
						<?php printf( __( '%s', 'lectura-lite' ), sprintf( '<cite class="comment-author-name">%s</cite>', get_comment_author_link() ) ); ?>
						<span class="comment-timestamp"><?php printf( __('%1$s at %2$s', 'lectura-lite'), get_comment_date(), get_comment_time()); ?></span><?php edit_comment_link( __( 'Edit', 'lectura-lite' ), ' <span class="comment-bullet">&#8226;</span> ' ); ?>
	
						<div class="comment-content">
						<?php if ( $comment->comment_approved == '0' ) : ?>
						<p class="comment-awaiting-moderation"><?php esc_html_e( 'Your comment is awaiting moderation.', 'lectura-lite' ); ?></p>
						<?php endif; ?>
	
						<?php comment_text(); ?>
						</div><!-- .comment-content -->

					</div><!-- .comment-body -->
	
					<div class="cleaner">&nbsp;</div>
				
				</div><!-- #comment-<?php comment_ID(); ?> -->
		
			</li><!-- #li-comment-<?php comment_ID(); ?> -->
		
			<?php
		break;

		case 'pingback'  :
		case 'trackback' :
			?>
			<li <?php comment_class(); ?> id="li-comment-<?php comment_ID(); ?>">
				<p><?php esc_html_e( 'Pingback:', 'lectura-lite' ); ?> <?php comment_author_link(); ?><?php edit_comment_link( __( '(Edit)', 'lectura-lite' ), ' ' ); ?></p>
			</li>
			<?php
		break;
	
	endswitch;
}

/* Add theme customizer to <head> 
================================== */

function lectura_lite_customizer_head() {

	/*
	This block refers to the functionality of the Appearance > Customize screen.
	*/
	
	$academia_bordercolor_header = esc_attr(get_theme_mod( 'lectura_lite_bordercolor_header' ));
	$academia_color_menu = esc_attr(get_theme_mod( 'lectura_lite_bgcolor_menu' ));
	$academia_color_body = esc_attr(get_theme_mod( 'lectura_lite_color_body' ));
	$academia_color_link = esc_attr(get_theme_mod( 'lectura_lite_color_link' ));
	$academia_color_link_hover = esc_attr(get_theme_mod( 'lectura_lite_color_link_hover' ));
	
	if( $academia_bordercolor_header != '' || $academia_color_menu != '' || $academia_color_body != '' || $academia_color_link != '' || $academia_color_link_hover != '') {
		echo '<style type="text/css">';
		if ($academia_bordercolor_header != '') {
			echo 'header { border-top-color: '.$academia_bordercolor_header.'; } ';
		}
		if ($academia_color_menu != '') {
			echo '#menu-main { background-color: '.$academia_color_menu.'; } ';
		}
		if ($academia_color_body != '') {
			echo 'body { color: '.$academia_color_body.'; } ';
		}
		if ($academia_color_link != '') {
			echo 'a { color: '.$academia_color_link.'; } ';
		}
		if ($academia_color_link_hover != '') {
			echo 'a:hover, a:focus { color: '.$academia_color_link_hover.'; } ';
		}

		echo '</style>';
	}

}
add_action('wp_head', 'lectura_lite_customizer_head');

/* Include WordPress Theme Customizer
================================== */

require_once('academia-admin/academia-customizer.php');

/* Include Additional Options and Components
================================== */

if ( !function_exists( 'get_the_image' ) ) {
	require_once('academia-admin/components/get-the-image.php');
}
require_once('academia-admin/post-options.php');