<?php
include('./services/ApiService.php');
include('./models/User.php');

$pages = ['users_list', 'add_update_user', 'delete_user'];
$controller = $_GET['page'] ?? 'users_list';
$controller = !in_array($controller, $pages) ? 'users_list' : $controller;
$api_service = new ApiService('http://192.168.42.210:8000/api/Users');

include('./includes/header.php');
?>
<container class="content">
    <div class="vh-100">
        <?php include("./controllers/${controller}.php") ?>
    </div>
</container>
<?php include('./includes/footer.php') ?>