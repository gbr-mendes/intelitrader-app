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
    $name = $_POST['name'];
    $surName = $_POST['surName'];
    $age = $_POST['age'];

    try {
        $user = new AddUpdateUserDto($name, $surName, $age);
        $alert_class = "alert-success";
        if ($method == "POST") {
            $response = $api_service->add_user($user);
            if (isset($response->statusCode) && $response->statusCode == 201) {
                $alert_message = $response->message;
                $name = '';
                $surName =  '';
                $age = '';
            }
        } elseif ($method == "PUT") {
            $response = $api_service->update_user($user, $_GET['user_id']);
            if (isset($response->name)) {
                $alert_message = "User updated successfully";
            } else {
                $alert_class = "alert-danger";
                $alert_message = "Ocorreu um erro inseperado";
            }
        }
    } catch (Exception $e) {
        $alert_message = $e->getMessage();
        $alert_class = 'alert-danger';
    }
}

include('./views/add_update_user.php');
