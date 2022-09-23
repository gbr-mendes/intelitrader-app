<?php

use Web\models\User;

$title = "Add User";
$method = "POST";
$alert_class = 'd-none';

if (isset($_GET['user_id'])) {
    try {
        $result = $user_services->get_user_by_id($_GET['user_id']);
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

        $alert_class = "alert-success";
        if (is_null($user->id)) {
            $newUser = $user_services->add_user($user);
            if ($newUser) {
                $alert_message = "User added successfully";
            } else {
                $alert_class = "alert-danger";
                $alert_message = "An unexpected error has occurred";
            }
        } else {
            $updatedUser = $user_services->update_user($user);
            if ($updatedUser) {
                $alert_message = "User updated successfully";
                $name = $user->name;
                $surName = $user->surName;
                $age = $user->age;
            } else {
                $alert_class = "alert-danger";
                $alert_message = "An unexpected error has occurred";
            }
        }
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
}

include('./views/add_update_user.php');
