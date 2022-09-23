<?php

namespace Web;

use Web\services\Api_service;
use Web\services\UserServices;

include('./models/User.php');
include('./services/Api_service.php');
include('./services/UserServices.php');


$pages = ['users_list', 'add_update_user', 'delete_user'];
$controller = $_GET['page'] ?? 'users_list';
$controller = !in_array($controller, $pages) ? 'users_list' : $controller;
$api_service = new Api_service('http://192.168.42.210:8000/api/Users');
$user_services = new UserServices($api_service);

include('./includes/header.php');
?>
<container class="content">
    <div class="vh-100">
        <?php include("./controllers/${controller}.php") ?>
    </div>
</container>
<?php include('./includes/footer.php') ?>