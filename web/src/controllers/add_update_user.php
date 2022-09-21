<?php
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
        $user = new AddUpdateUserDto($_POST);
        $alert_class = "alert-success";
        if ($method == "POST") {
            $response = $api_service->add_user($user);
            if (isset($response->statusCode) && $response->statusCode == 201) {
                $alert_message = $response->message;
            }
        } elseif ($method == "PUT") {
            $result = $api_service->update_user($user, $_GET['user_id']);
            if (isset($result->name)) {
                $name = $result->name;
                $surName = $result->surName ?? '';
                $age = $result->age ?? '';
                $alert_message = "User updated successfully";
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
