
function hideAll() {
    $("#addForm").css("display", "none");
    $("#updForm").css("display", "none");
    $("#delForm").css("display", "none");
  }

  $("#addBtn").on("click", function () {
    console.log("Delete Tab");
    hideAll();
    $("#addForm").css("display", "block");
  });

  $("#updBtn").on("click", function () {
    console.log("Delete Tab");
    hideAll();
    $("#updForm").css("display", "block");
  });

  $("#delBtn").on("click", function () {
    console.log("Delete Tab");
    hideAll();
    $("#delForm").css("display", "block");
  });

  window.onload = function () {
    $("#addForm").css("display", "block");
  }
