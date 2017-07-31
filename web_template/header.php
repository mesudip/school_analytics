<!DOCTYPE html>
<html <?php language_attributes(); ?>>
	<head>
		<meta charset="<?php bloginfo( 'charset' ); ?>" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<link rel="profile" href="http://gmpg.org/xfn/11" />
		<link rel="pingback" href="<?php bloginfo( 'pingback_url' ); ?>" />
	<?php wp_head(); ?>
</head>

<body <?php body_class(); ?>>

<div id="container">

	<div class="wrapper wrapper-main">
	
		<header role="banner" class="site-header">
		
			<div class="wrapper wrapper-header">
			
				<div id="logo">
					<?php if (get_theme_mod('lectura_lite_logo_upload') != '') { ?>
					<a href="<?php echo esc_url(home_url('/')); ?>" title="<?php bloginfo('description'); ?>">
						<img src="<?php echo esc_url(get_theme_mod('lectura_lite_logo_upload')); ?>" alt="<?php bloginfo('name'); ?>" class="logo-img" />
					</a>
					<?php } else { ?>
					<span class="logo-title"><a href="<?php echo esc_url(home_url('/')); ?>" id="logo-anchor"><?php bloginfo('name'); ?></a></span>
					<p class="logo-tagline"><?php bloginfo('description'); ?></p>
					<?php } ?>
				</div><!-- #logo -->

				<?php if (has_nav_menu( 'secondary' )) { ?>
				<div id="useful-menu" role="navigation">
					
					<?php wp_nav_menu( array('container' => '', 'container_class' => '', 'menu_class' => 'useful-menu', 'menu_id' => 'menu-secondary-menu', 'sort_column' => 'menu_order', 'depth' => '1', 'theme_location' => 'secondary') ); ?>

				</div><!-- #useful-menu -->
				<?php }	?>
				
				<div class="cleaner">&nbsp;</div>
				
			</div><!-- .wrapper .wrapper-header -->
		
			<div class="wrapper wrapper-menu">

				<nav id="menu-main">

					<a class="btn_menu" id="toggle-main" href="#"></a>

					<?php if (has_nav_menu( 'primary' )) { 
						wp_nav_menu( array(
							'container' => '', 
							'container_class' => '', 
							'menu_class' => 'navbar-nav dropdown sf-menu clearfix', 
							'menu_id' => 'menu-main-menu',
							'sort_column' => 'menu_order', 
							'theme_location' => 'primary', 
							'items_wrap' => '<ul id="%1$s" class="%2$s">%3$s</ul>'
						) );
					}
					else
					{

						if (current_user_can('edit_theme_options')) {
							echo '<div id="menu-main-menu"><p class="academia-notice">';
							echo __('Please set your Main Menu on this page:','lectura-lite') . '<a href="'.get_admin_url( '', 'nav-menus.php' ).'"> ' . __('Appearance > Menus','lectura-lite') . '</a><br>';
							echo __('Other options and theme elements can be set up on this page:','lectura-lite') . '<a href="'.get_admin_url( '', 'customize.php' ).'"> ' . __('Appearance > Customize','lectura-lite') . '</a>';
							echo '</p></div>';
						}

					}
					?>

				</nav><!-- #menu-main -->

			</div><!-- .wrapper .wrapper-menu -->
		
		</header><!-- .site-header -->