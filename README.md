# DispatX - Lightweight Dispatcher for .NET

DispatX یک Dispatcher سبک و ساده برای مدیریت ارسال درخواست‌ها (Request/Query/Command) در پروژه‌های .NET است.  
این پروژه یک نمونه Web API است که نحوه استفاده از DispatX را نشان می‌دهد.

---

## 🚀 شروع سریع

### کلون پروژه

```bash
git clone https://github.com/your-username/DispatX.git
cd DispatX
```

### اجرای پروژه Web API

```bash
dotnet run --project DispatX.WebApi
```

---

## 📁 ساختار پروژه

- **DispatX.Dispatcher**  
  شامل پیاده‌سازی اصلی Dispatcher و اینترفیس‌های مرتبط.

- **DispatX.WebApi**  
  پروژه Web API نمونه برای نمایش استفاده از Dispatcher.

- **DispatX.WebApi.Handlers**  
  شامل Handlerهای درخواست‌ها مثل `GetUsersQueryHandler`.

---

## 🛠 نحوه استفاده

### ثبت Dispatcher در DI

در `Program.cs` به سادگی سرویس Dispatcher را اضافه کنید:

```csharp
builder.Services.AddDispatcher();
```

### ارسال درخواست به Dispatcher

در یک endpoint یا سرویس، درخواست خود را به Dispatcher بفرستید:

```csharp
app.Map("/users/{count:int}", async (IDispatcher dispatcher, int count) =>
{
    var data = await dispatcher.SendAsync(new GetUsersQuery { Count = count });
    return Results.Ok(data);
});
```
 
---

## 🧪 تست و اجرا

بعد از اجرای پروژه:

- باز کردن مرورگر و آدرس:  

- فراخوانی:  
  `https://localhost:5001/users/5`  
 
 
