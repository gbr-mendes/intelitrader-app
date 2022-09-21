<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1>Users List</h1>
    <div class="alert <?php echo isset($alert_class) ? $alert_class : 'd-none' ?>" role="alert">
        <?php echo isset($alert_message) ? $alert_message : null ?>
    </div>
    <div class="user-list col-10 col-md-4 p-4">
        <?php foreach ($users as $user) : ?>
            <div class="user d-flex justify-content-between align-items-center p-2">
                <h6><?php echo "{$user->name} {$user->surName}"; ?></h6>
                <div class="user-actions">
                    <div class="d-flex justify-content-center align-items-center">
                        <a href="<?php echo "?page=add_update_user&user_id={$user->id}" ?>" class="me-2"><i class="fa-solid fa-pen-to-square fa-lg"></i></a>
                        <form action="controllers/delete_user.php<?= "?user_id={$user->id}" ?>" method="POST">
                            <button type="submit" class="btn" name="delete">
                                <i class="fa-solid fa-trash fa-lg"></i>
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        <?php endforeach; ?>
    </div>
</div>