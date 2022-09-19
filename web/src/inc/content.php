<?php
if (isset($_GET['page'])) {
    $page = $_GET['page'];
} else {
    $page = 'users_list';
}
include("./inc/pages/${page}.php");
