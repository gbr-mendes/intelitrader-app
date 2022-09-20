<?php
$title = "Add User";
$method = "POST";
$alert_class = 'd-none';
$alert_message = '';

if (isset($_GET['user_id']) && $_GET['user_id'] != '' && !isset($_GET['update'])) {
    $result = $api_service->get_user_by_id($_GET['user_id']);
    $title = isset($result->id) ? "Update User" : "Add User";
    $method = isset($result->id) ? "PUT" : "POST";
    $name = $result->name;
    $surName = $result->surName;
    $age = $result->age;
} elseif (isset($_GET['user_id']) && $_GET['user_id'] != '' && isset($_GET['update'])) {
    $method = "PUT";
}

if (isset($_POST['submit'])) {
    include('../../services/ApiService.php');
    include('../../models/AddUpdateUserDto.php');
    $api_service = new ApiService('http://192.168.42.210:8000/api/Users');
    $name = $_POST['name'];
    $surName = $_POST['surName'];
    $age = $_POST['age'];
    try {
        $user = new AddUpdateUserDto($name, $surName, $age);
        if ($method == "POST") {
            $response = $api_service->add_user($user);
            if (isset($response->statusCode) && $response->statusCode == 201) {
                $alert_class = "alert-success";
                $alert_message = $response->message;
                header("Location: /index.php?page=add_update_user&message=${alert_message}&alert_class=${alert_class}");
            }
        } elseif ($method == "PUT") {
            $response = $api_service->update_user($user, $_GET['user_id']);
            if (isset($response->name)) {
                $alert_class = "alert-success";
                $alert_message = "User updated successfully";
                $name = $response->name;
                $surName = $response->surName;
                $age = $response->age;
                header("Location: /index.php?page=add_update_user&user_id={$_GET['user_id']}&message=${alert_message}&alert_class=${alert_class}");
            } else {
                $alert_class = "alert-danger";
                $alert_message = "Ocorreu um erro inseperado";
            }
        }
    } catch (Exception $exception) {
        $alert_message = $exception->getMessage();
        $alert_class = 'alert-danger';
        if ($method == "PUT") {
            header("Location: /index.php?page=add_update_user&user_id={$_GET['user_id']}&message=${alert_message}&alert_class=${alert_class}");
        } else {
            header("Location: /index.php?message=${alert_message}&alert_class=${alert_class}");
        }
    }
}
?>

<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1><?php echo $title ?></h1>
    <div class="add-update-form mt-5 col-8 col-md-4">
        <div class="alert <?php echo isset($_GET['message']) && isset($_GET['alert_class']) && $_GET['message'] !== '' ? $_GET['alert_class'] : 'd-none' ?>" role="alert">
            <?php echo isset($_GET['message']) && $_GET['message'] !== '' ? $_GET['message'] : null ?>
        </div>
        <form action="inc/pages/add_update_user.php<?php echo isset($_GET['user_id']) ? "?user_id={$_GET['user_id']}&update=true" : null ?>" method="POST">
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="name" class="me-2 col-3">Name:</label>
                <input type="text" class="form-control col-9" name="name" placeholder="Type your name" id="name" value="<?php echo isset($name) ? $name : '' ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="surname" class="me-2 col-3">Surname:</label>
                <input type="text" class="form-control col-9" name="surName" placeholder="Type your surname" id="surname" value="<?php echo isset($surName) ? $surName : '' ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="age" class="me-2 col-3">Age:</label>
                <input type="number" min="1" class="form-control col-9" name="age" placeholder="Type your age" id="age" value="<?php echo isset($age) ? $age : '' ?>">
            </div>
            <div class="d-flex justify-content-center align-items-center">
                <button type="submit" class="btn form-btn" name="submit">
                    <?php echo $title; ?>
                </button>
            </div>
        </form>
    </div>
</div>