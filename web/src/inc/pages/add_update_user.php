<?php
$title = "Add User";
$method = "POST";

if (isset($_GET['user_id']) && $_GET['user_id'] != '') {
    $result = $api_service->get_user_by_id($_GET['user_id']);
    $title = isset($result->id) ? "Update User" : "Add User";
    $method = isset($result->id) ? "PUT" : "POST";
}

?>
<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1><?php echo $title ?></h1>
    <div class="add-update-form mt-5 col-8 col-md-4">
        <form action="#" method=<?php echo $method ?>>
            <div class="d-flex justify-content-center align-items-center col-12 m-3">
                <div class="alert alert-danger col-12 <?php echo !isset($result->message) ? 'd-none' : null  ?>" role="alert">
                    <?php echo isset($result->message) ? $result->message : null ?>
                </div>
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="name" class="me-2 col-3">Name:</label>
                <input type="text" class="form-control col-9" name="name" placeholder="Type your name" id="name" value="<?php echo isset($result->name) ? $result->name : '' ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="surname" class="me-2 col-3">Surname:</label>
                <input type="text" class="form-control col-9" name="surname" placeholder="Type your surname" id="surname" value="<?php echo isset($result->surName) ? $result->surName : "" ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="age" class="me-2 col-3">Age:</label>
                <input type="number" min="1" class="form-control col-9" name="age" placeholder="Type your age" id="age" value="<?php echo isset($result->age) ? $result->age : '' ?>">
            </div>
            <div class="d-flex justify-content-center align-items-center">
                <button type="submit" class="btn form-btn">
                    <?php echo $title; ?>
                </button>
            </div>
        </form>
    </div>
</div>