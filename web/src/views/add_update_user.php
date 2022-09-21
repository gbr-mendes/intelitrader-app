<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1><?php echo $title ?></h1>
    <div class="add-update-form mt-5 col-8 col-md-4">
        <div class="alert <?php echo isset($alert_message) && isset($alert_class) && $alert_message !== '' ? $alert_class : 'd-none' ?>" role="alert">
            <?= $alert_message ?? '' ?>
        </div>
        <form action="<?= htmlspecialchars($_SERVER["PHP_SELF"]) ?>?page=add_update_user<?= isset($_GET['user_id']) ? "&user_id={$_GET['user_id']}" : null ?>" method="POST">
            <input type="text" value="<?= $_GET['user_id'] ?? '' ?>" class="d-none" name="<?= isset($_GET['user_id']) ? 'id' : null ?>">
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="name" class="me-2 col-3">Name:</label>
                <input type="text" class="form-control col-9" name="name" placeholder="Type your name" id="name" value="<?php echo $name ?? '' ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="surname" class="me-2 col-3">Surname:</label>
                <input type="text" class="form-control col-9" name="surName" placeholder="Type your surname" id="surname" value="<?php echo $surName ?? '' ?>">
            </div>
            <div class="form-group d-flex justify-content-center align-items-center col-12 m-3">
                <label for="age" class="me-2 col-3">Age:</label>
                <input type="number" min="1" class="form-control col-9" name="age" placeholder="Type your age" id="age" value="<?php echo $age ?? '' ?>">
            </div>
            <div class="d-flex justify-content-center align-items-center">
                <button type="submit" class="btn form-btn" name="submit">
                    <?php echo $title; ?>
                </button>
            </div>
        </form>
    </div>
</div>