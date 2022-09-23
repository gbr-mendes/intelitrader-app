<?php
$users = [];
$alert_message = $_GET['message'] ?? null;
$alert_class = $_GET['alert_class'] ?? null;
try {
    $users = $user_services->get_users();
} catch (Exception $exception) {
    $alert_message = "An unexpected error has occured";
}
include('./views/users_list.php');
