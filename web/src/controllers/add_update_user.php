<?php

use Web\models\User;

$title = "Add User";
$method = "POST";
$alert_class = 'd-none';

if (isset($_GET['user_id'])) {
    try {
        $result = $api_service->get_user_by_id($_GET['user_id']);
        $title = isset($result->id) ? "Update User" : "Add User";
        $method = isset($result->id) ? "PUT" : "POST";
        $name = $result->name ?? '';
        $surName = $result->surName ?? '';
        $age = $result->age ?? '';
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
}

if (isset($_POST['submit'])) {
    try {
        $user = new User($_POST, $api_service);
        $newUser = $user->save_user();
        if ($newUser) {
            $alert_class = "alert-success";
            if ($method == "POST") {
                $alert_message = "User added successfully";
            } else {
                $alert_message = "User updated successfully";
                $name = $user->name;
                $surName = $user->surName;
                $age = $user->age;
            }
        } else {
            $alert_class = "alert-danger";
            $alert_message = "An unexpected error has occurred";
        }
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
}

include('./views/add_update_user.php');
