<?php			

/**
 * Adds the individual sections, settings, and controls to the theme customizer
 */

function lectura_lite_customizer( $wp_customize ) {
	
	$wp_customize->add_section(
		'lectura_lite_section_general',
		array(
			'title' => __('General Settings','lectura-lite'),
			'description' => __('This controls various general theme settings.','lectura-lite'),
			'priority' => 5,
		)
	);

	$wp_customize->add_section(
		'lectura_lite_section_homepage',
		array(
			'title' => __('Homepage Settings','lectura-lite'),
			'description' => __('This controls various homepage theme settings.','lectura-lite'),
			'priority' => 25,
		)
	);

	$wp_customize->add_section(
		'lectura_lite_section_colors',
		array(
			'title' => __('Color Settings','lectura-lite'),
			'description' => __('Customize some basic theme colors.','lectura-lite'),
			'priority' => 35,
		)
	);


	$wp_customize->add_setting( 
		'lectura_lite_logo_upload',
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'esc_url_raw',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Upload_Control(
			$wp_customize,
			'file-upload',
			array(
				'label' => __('Logo File Upload','lectura-lite'),
				'section' => 'lectura_lite_section_general',
				'settings' => 'lectura_lite_logo_upload'
			)
		)
	);

	$copyright_default = __('Copyright &copy; ','lectura-lite') . date("Y",time()) . ' ' . get_bloginfo('name') . '. ' . __('All Rights Reserved', 'lectura-lite');
	$wp_customize->add_setting(
		'lectura_lite_copyright_text',
		array(
			'default' => $copyright_default,
			'sanitize_callback' => 'esc_html',
		)
	);

	$wp_customize->add_control(
		'lectura_lite_copyright_text',
		array(
			'label' => __('Copyright text in Footer','lectura-lite'),
			'section' => 'lectura_lite_section_general',
			'type' => 'text',
		)
	);

	$wp_customize->add_setting(
		'lectura_lite_display_slideshow', 
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'esc_html',
			'default' => 0,
	));
	
	$wp_customize->add_control(
		'lectura_lite_display_slideshow',
		array(
			'label'      => __('Display Slideshow', 'lectura-lite'),
			'section'    => 'lectura_lite_section_homepage',
			'type'    => 'checkbox',
	));

	$wp_customize->add_setting(
		'lectura_lite_slideshow_number',
		array(
			'default' => '5',
			'sanitize_callback' => 'esc_html',
		)
	);

	$wp_customize->add_control(
		'lectura_lite_slideshow_number',
		array(
			'label' => __('Number of Images to Display','lectura-lite'),
			'section' => 'lectura_lite_section_homepage',
			'type' => 'text',
		)
	);	

	$wp_customize->add_setting(
		'lectura_lite_display_feat_pages', 
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'esc_html',
			'default' => 0,
	));
	
	$wp_customize->add_control(
		'lectura_lite_display_feat_pages', 
		array(
			'label'      => __('Display Featured Pages', 'lectura-lite'),
			'section'    => 'lectura_lite_section_homepage',
			'type'    => 'checkbox',
	));

	$wp_customize->add_setting(
		'lectura_lite_page_feat_1', 
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'lectura_lite_sanitize_integer',
	));
	
	$wp_customize->add_control(
		'lectura_lite_page_feat_1', 
		array(
			'label'      => __('Featured Page #1', 'lectura-lite'),
			'section'    => 'lectura_lite_section_homepage',
			'type'    => 'dropdown-pages',
	));
	
	$wp_customize->add_setting(
		'lectura_lite_page_feat_2', 
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'lectura_lite_sanitize_integer',
	));
	
	$wp_customize->add_control(
		'lectura_lite_page_feat_2', 
		array(
			'label'      => __('Featured Page #2', 'lectura-lite'),
			'section'    => 'lectura_lite_section_homepage',
			'type'    => 'dropdown-pages',
	));
	
	$wp_customize->add_setting(
		'lectura_lite_page_feat_3', 
		array(
			'capability'     => 'edit_theme_options',
			'sanitize_callback' => 'lectura_lite_sanitize_integer',
	));
	
	$wp_customize->add_control(
		'lectura_lite_page_feat_3', 
		array(
			'label'      => __('Featured Page #3', 'lectura-lite'),
			'section'    => 'lectura_lite_section_homepage',
			'type'    => 'dropdown-pages',
	));

	$wp_customize->add_setting(
		'lectura_lite_bordercolor_header',
		array(
			'default' => '222c43',
			'sanitize_callback' => 'sanitize_hex_color',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Color_Control(
			$wp_customize,
			'lectura_lite_bordercolor_header',
			array(
				'label' => __('Header top border color','lectura-lite'),
				'section' => 'lectura_lite_section_colors',
				'settings' => 'lectura_lite_bordercolor_header',
				'priority' => 2,
			)
		)
	);

	$wp_customize->add_setting(
		'lectura_lite_bgcolor_menu',
		array(
			'default' => '222c43',
			'sanitize_callback' => 'sanitize_hex_color',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Color_Control(
			$wp_customize,
			'lectura_lite_bgcolor_menu',
			array(
				'label' => __('Menu background color','lectura-lite'),
				'section' => 'lectura_lite_section_colors',
				'settings' => 'lectura_lite_bgcolor_menu',
				'priority' => 3,
			)
		)
	);

	$wp_customize->add_setting(
		'lectura_lite_color_body',
		array(
			'default' => '555555',
			'sanitize_callback' => 'sanitize_hex_color',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Color_Control(
			$wp_customize,
			'lectura_lite_color_body',
			array(
				'label' => __('Main body text color','lectura-lite'),
				'section' => 'lectura_lite_section_colors',
				'settings' => 'lectura_lite_color_body',
				'priority' => 4,
			)
		)
	);

	$wp_customize->add_setting(
		'lectura_lite_color_link',
		array(
			'default' => '26bcd7',
			'sanitize_callback' => 'sanitize_hex_color',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Color_Control(
			$wp_customize,
			'lectura_lite_color_link',
			array(
				'label' => __('Main body anchor(link) color','lectura-lite'),
				'section' => 'lectura_lite_section_colors',
				'settings' => 'lectura_lite_color_link',
			)
		)
	);

	$wp_customize->add_setting(
		'lectura_lite_color_link_hover',
		array(
			'default' => 'd8ae6e',
			'sanitize_callback' => 'sanitize_hex_color',
		)
	);

	$wp_customize->add_control(
		new WP_Customize_Color_Control(
			$wp_customize,
			'lectura_lite_color_link_hover',
			array(
				'label' => __('Main body anchor(link) :hover color','lectura-lite'),
				'section' => 'lectura_lite_section_colors',
				'settings' => 'lectura_lite_color_link_hover',
			)
		)
	);

}
add_action( 'customize_register', 'lectura_lite_customizer' );

function lectura_lite_sanitize_integer( $input ) {
	if( is_numeric( $input ) ) {
		return intval( $input );
	}
}