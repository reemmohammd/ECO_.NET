using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.BL.Dtos.User;

public record RegisterDto(string Username, string Email, string Password, string Address);
