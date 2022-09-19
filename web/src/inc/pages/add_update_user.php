<?php
$title = isset($_GET['user_id']) ? 'Update User' : 'Add User';
$method = isset($_GET['user_id']) ? 'PUT' : 'POST';
?>
<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1><?php echo $title ?></h1>
    <div class="add-update-form mt-5 col-8 col-md-4">
        <form action="#" method=<?php echo $method ?>>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="name" class="me-2 col-3">Name:</label>
                <input type="text" class="form-control col-9" name="name" placeholder="Type your name" id="name">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="surname" class="me-2 col-3">Surname:</label>
                <input type="text" class="form-control col-9" name="surname" placeholder="Type your surname" id="surname">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="age" class="me-2 col-3">Age:</label>
                <input type="number" min="1" class="form-control col-9" name="age" placeholder="Type your age" id="age">
            </div>
            <div class="d-flex justify-content-center align-items-center">
                <button type="submit" class="btn form-btn">
                    <?php echo $title; ?>
                </button>
            </div>
        </form>
    </div>
</div>